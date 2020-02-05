using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// wrmhlThread_ReadLines is derived from the common wrmhl Thread
public class wrmhlThread_Lines : wrmhlThread {

    // This constructor will call wrmhlThread.wrmhlThread(string portName, int baudRate, int readTimeout)
    public wrmhlThread_Lines(string portName, int baudRate, int readTimeout, int QueueLength) : base(portName, baudRate, readTimeout, QueueLength) {
    }

    // This constructor will call wrmhlThread.wrmhlThread(string portName, int baudRate)
    public wrmhlThread_Lines(string portName, int baudRate) : base(portName, baudRate){
    }

    public override string ReadProtocol() {
        return deviceSerial.ReadLine();
    }

    public override void SendProtocol(object message) {
        deviceSerial.WriteLine((string) message);
    }
}
