using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to write the data to the device
public class rtaumExample : MonoBehaviour {

    // rtaum is the bridge between your computer and hardware
    rtaum.DeviceReader myDevice = new rtaum.DeviceReader();

    [Tooltip("SerialPort of your device.")]
    public string portName = "COM6";

    [Tooltip("Baud Rate")]
    public int baudRate = 250000;

    [Tooltip("Timeout")]
    public int ReadTimeout = 20;

    [Tooltip("Something you want to send")]
    public string dataToSend = "Hello World!";

    [Tooltip("Queue Length")]
    public int QueueLength = 1;

    private SyncRate sendingRate = new SyncRate(5);

    void Start() {
        // This method set the communication with the following vars
        myDevice.Set(portName, baudRate, ReadTimeout, QueueLength);
        // This method open the Serial communication with the vars previously given
        myDevice.Connect();
    }

    // Update is called once per frame
    void Update() {
        if (sendingRate.Run()) {
            Debug.Log("reading: '" + myDevice.ReadQueue() + "'");
            // Send data to the device using a thread
            myDevice.Send(dataToSend);
        }
    }

    // Close the Thread and Serial Port
    void OnApplicationQuit() {
        myDevice.Close();
    }
}
