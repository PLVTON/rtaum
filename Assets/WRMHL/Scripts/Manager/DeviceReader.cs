using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wrmhl {
    // This class allow you to establish the connection between your device and Unity by setting-up Thread and manage these Thread
    public class DeviceReader {

        // Uses wrmhlThread_ReadLines class derived from wrmhlTread
        private IOThreadLines deviceReader;

        // Creates the thread with the variables needed for connecting your device and Unity
        public void set(string portName, int baudRate, int readTimeout, int QueueLength) {
            deviceReader = new IOThreadLines(portName, baudRate, readTimeout, QueueLength);                                             
        }

        // Setting up the connection between your device and Unity without readTimeout
        public void set(string portName, int baudRate) {
            deviceReader = new IOThreadLines(portName, baudRate);      
        }

        // Connect the device and unity
        public void connect() {
            // Open the Serial Port data flow first
            deviceReader.openFlow();
            deviceReader.startThread();
        }

        // Disconnect the device and unity
        public void close() {
            deviceReader.StopThread();
        }

        // Read the data from your device
        public string readQueue() {
            return deviceReader.readQueueThread();
        }

        // Sends the data to your device
        public void send(string dataToSend) {
            deviceReader.writeThread(dataToSend);
        }
    }
}