using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rtaum {
    // IOThreadLines inherits IOThread
    public class IOThreadLines : IOThread {

        public IOThreadLines(string portName, int baudRate, int readTimeout, int QueueLength) : base(portName, baudRate, readTimeout, QueueLength) { }

        public IOThreadLines(string portName, int baudRate) : base(portName, baudRate) { }

        public override string ReadProtocol() {
            return deviceSerial.ReadLine();
        }

        public override void SendProtocol(object message) {
            deviceSerial.WriteLine((string) message);
        }
    }
}
