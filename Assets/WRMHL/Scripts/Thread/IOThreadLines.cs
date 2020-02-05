using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wrmhl {
    // wrmhlThread_ReadLines is derived from the common wrmhl IOThread
    public class IOThreadLines : IOThread {

        // This constructor will call wrmhlThread.wrmhlThread(string portName, int baudRate, int readTimeout)
        public IOThreadLines(string portName, int baudRate, int readTimeout, int QueueLength) : base(portName, baudRate, readTimeout, QueueLength) {
        }

        // This constructor will call wrmhlThread.wrmhlThread(string portName, int baudRate)
        public IOThreadLines(string portName, int baudRate) : base(portName, baudRate) {
        }

        public override string ReadProtocol() {
            return deviceSerial.ReadLine();
        }

        public override void SendProtocol(object message) {
            deviceSerial.WriteLine((string) message);
        }
    }
}
