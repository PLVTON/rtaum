using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bbaum {
    // This class allow you to establish the connection between your device and Unity by setting-up Thread and manage these Thread
    public class DeviceReader {

        // Uses IOThreadLines class derived from IOThread
        private IOThreadLines deviceReader;

        // Creates the thread with the variables needed for connecting your device and Unity
        public void Set(string portName, int baudRate, int readTimeout, int QueueLength) {
            deviceReader = new IOThreadLines(portName, baudRate, readTimeout, QueueLength);                                             
        }

        // Connect the device and unity
        public void Connect() {
            // Open the Serial Port data flow first
            deviceReader.OpenFlow();
            deviceReader.StartThread();
        }

        // Disconnect the device and unity
        public void Close() {
            deviceReader.StopThread();
        }

        // Read the data from your device
        public string ReadQueue() {
            return deviceReader.ReadQueueThread();
        }

        // Sends the data to your device
        public void Send(string dataToSend) {
            deviceReader.WriteThread(dataToSend);
        }
    }
}