using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to write the data to the device
public class wrmhlWrite : MonoBehaviour {

    // wrmhl is the bridge beetwen your computer and hardware
    wrmhl.DeviceReader myDevice = new wrmhl.DeviceReader();

    [Tooltip("SerialPort of your device.")]
    public string portName = "COM8";

    [Tooltip("Baud Rate")]
    public int baudRate = 250000;

    [Tooltip("Timeout")]
    public int ReadTimeout = 20;

    [Tooltip("Something you want to send")]
    public string dataToSend = "Hello World!";

    [Tooltip("QueueLength")]
    public int QueueLength = 1;

    void Start() {
        // This method set the communication with the following vars
        myDevice.Set(portName, baudRate, ReadTimeout, QueueLength);
        // This method open the Serial communication with the vars previously given
        myDevice.Connect();
    }

    // Update is called once per frame
    void Update() {
        // Send data to the device using thread
        myDevice.Send(dataToSend);
    }

    // Close the Thread and Serial Port
    void OnApplicationQuit() {
        myDevice.Close();
    }
}
