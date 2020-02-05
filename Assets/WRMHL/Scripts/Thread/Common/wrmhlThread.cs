using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;

public abstract class wrmhlThread {

    // wrmhlThread is the common Thread for receiving and sending data, but it's protocols depend on the derived class you use.
    // Protocols are definined by this.ReadProtocol() and this.SendProtocol() which are overide by the top layer of this class.
    // As of right now, the only top layer is wormhlThread_ReadLines.

    public SerialPort deviceSerial;
    public bool looping = true;

    private string portName;
    private int baudRate;
    private int readTimeout = 100;

    private Thread WRMHLthread;

    // From Unity to Arduino
    private Queue outputQueue;
    // From Arduino to Unity
    private Queue inputQueue;

    private int QueueLength = 1;

    // Constructor take the vars coming from wrmhl
    public wrmhlThread(string portName, int baudRate, int readTimeout, int QueueLength) {
        this.portName = portName;
        this.baudRate = baudRate;
        this.readTimeout = readTimeout;
        this.QueueLength = QueueLength;
    }

    // No readTimeout
    public wrmhlThread(string portName, int baudRate) { 
        this.portName = portName;
        this.baudRate = baudRate;
    }

    // Creates and starts the thread
    public void startThread() {
        outputQueue = Queue.Synchronized( new Queue() );
        inputQueue  = Queue.Synchronized( new Queue() );

        WRMHLthread = new Thread (ThreadLoop);
        WRMHLthread.Start ();
    }

    // Open the SerialPort with the vars given by wrmhl
    public void openFlow() {
        // Define the SerialPort
        deviceSerial = new SerialPort(this.portName, this.baudRate);
        // Set the readTimeout
        deviceSerial.ReadTimeout = this.readTimeout;
        // Start the data Flow
        deviceSerial.Open();
    }

    // This method is used to stop the thread
    public void StopThread () {
        lock (this) {
            // This var is used for the thread's while loop by the threadIsLooping method
            looping = false;
        }
    }

    // This method is used to return to the thread's looping value
    public bool threadIsLooping () {
        lock (this) {
            return looping;
        }
    }

    // Return the data stocked in the Queue. Independent from the protocol
    public string readQueueThread() { 
        if (inputQueue.Count == 0)
            return null;

        return (string)inputQueue.Dequeue ();
    }

    // [TO-DO] Return the data stocked in the Queue. Independent from the protocol
    public string readLatestThread() { 
        return null; // TO DO: Delete it
    }

    // Add the data to the write Queue. Independent from the protocol
    public void writeThread(string dataToSend) {
        outputQueue.Enqueue (dataToSend);
    }

    // Main thread loop
    public void ThreadLoop() {
        while (threadIsLooping ()) {
            // Read data
            object dataComingFromDevice = ReadProtocol();
            if (dataComingFromDevice != null) {
                if (inputQueue.Count < QueueLength) {
                    inputQueue.Enqueue(dataComingFromDevice);
                }
            }
            // Send data
            if (outputQueue.Count != 0) {
                object dataToSend = outputQueue.Dequeue();
                SendProtocol(dataToSend);
            }
        }

        // Close the data Flow
        deviceSerial.Close(); 
    }

    public abstract string ReadProtocol();
    public abstract void SendProtocol(object message); 
}
