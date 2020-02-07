using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;

namespace bbaum {
    public abstract class IOThread {

        // IOThread is the common Thread for receiving and sending data, but it's protocols depend on the derived class you use.
        // Protocols are definined by this.ReadProtocol() and this.SendProtocol() which are overridden by the top layer of this class.
        // As of right now, the only top layer is IOThreadLines.

        public SerialPort deviceSerial;
        public bool looping = true;

        private string portName;
        private int baudRate;
        private int readTimeout = 100;

        private Thread thread;

        // From Unity to Arduino
        private Queue outputQueue;
        // From Arduino to Unity
        private Queue inputQueue;

        private int QueueLength = 1;

        // Constructor take the variables coming from bbaum
        public IOThread(string portName, int baudRate, int readTimeout, int QueueLength) {
            this.portName = portName;
            this.baudRate = baudRate;
            this.readTimeout = readTimeout;
            this.QueueLength = QueueLength;
        }

        // No readTimeout
        public IOThread(string portName, int baudRate) { 
            this.portName = portName;
            this.baudRate = baudRate;
        }

        // Creates and starts the thread
        public void StartThread() {
            outputQueue = Queue.Synchronized(new Queue());
            inputQueue = Queue.Synchronized(new Queue());

            thread = new Thread(ThreadLoop);
            thread.Start();
        }

        // Open the SerialPort with the parameters given by bbaum
        public void OpenFlow() {
            deviceSerial = new SerialPort(this.portName, this.baudRate);
            deviceSerial.ReadTimeout = this.readTimeout;
            deviceSerial.Open();
        }

        // This method is used to stop the thread
        public void StopThread() {
            lock (this) {
                // This var is used for the thread's while loop by the threadIsLooping method
                looping = false;
            }
        }

        // This method is used to return to the thread's looping value
        public bool ThreadIsLooping() {
            lock (this) {
                return looping;
            }
        }

        // Return the data stocked in the Queue. Independent from the protocol
        public string ReadQueueThread() { 
            if (inputQueue.Count == 0)
                return null;

            return (string)inputQueue.Dequeue();
        }

        // Add the data to the write Queue. Independent from the protocol
        public void WriteThread(string dataToSend) {
            outputQueue.Enqueue(dataToSend);
        }

        // Main thread loop
        public void ThreadLoop() {
            while (ThreadIsLooping()) {
                // Read data
                try {
                    object dataComingFromDevice = ReadProtocol();
                    if (dataComingFromDevice != null) {
                        if (inputQueue.Count < QueueLength) {
                            inputQueue.Enqueue(dataComingFromDevice);
                        }
                    }
                }
                catch (System.Exception) { }
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
}