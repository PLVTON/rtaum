using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
In order to queue the results (thus not losing any data), increase the Queue.

If arduino send ->
    {"1",
    "2",
    "3",}
readQueue() will return ->
    "1", for the first call
    "2", for the second call
    "3", for the thirst call

*/

public class wrmhlRead : MonoBehaviour {

    // wrmhl is the bridge beetwen your computer and hardware
    wrmhl.DeviceReader myDevice = new wrmhl.DeviceReader();

    [Tooltip("SerialPort of your device.")]
    public string portName = "COM8";

    [Tooltip("Baud Rate")]
    public int baudRate = 250000;

    [Tooltip("Timeout")]
    public int ReadTimeout = 20;

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
        // myDevice.readQueue() return the data coming from the device using thread
        Debug.Log(myDevice.ReadQueue()); 
    }

    void OnApplicationQuit() {
        // Close the Thread and Serial Port
        myDevice.Close();
    }
}
