using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncRate {

    private float timeStamp = 0;
    private int syncRate;
    
    // The syncRate is in Frames Per Second
    public SyncRate(int syncRate = 5) {
        this.syncRate = syncRate;
    }

    // Set the rate to a different value
    public void SetRate(int newSyncRate) {
        this.syncRate = newSyncRate;
    }

    // Returns true if the rate was ready
    // In this case, it will also set the next ready timestamp
    public bool Run() {
        if (Time.time >= this.timeStamp) {
            this.timeStamp = Time.time + (1f / (float) this.syncRate);
            return true;
        }
        return false;
    }
}
