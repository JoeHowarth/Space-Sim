using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Galaxy {
    /*
     * Top level data element for the game
     * Orchestrates 
     *   - setup
     *   - steps
     */
    static public Galaxy G { get; protected set; }
    public List<StarSystem> Systems;

    //public int Day { get { return Day; } private set { Day = value;} }
    public int Day;
    Action<int> onDayChanged;
    public void RegisterDayChanged (Action<int> cb) { onDayChanged += cb; }

    public Galaxy (int numSystems = 1) {
        //Debug.Log ("Galaxy creation started...");

        // set static instance
        if (G != null) {
            Debug.LogError ("Only 1 Galaxy allowed!");
        }
        //Debug.Log ("before day initialization");

        G = this;
        Day = 0;

        Systems = new List<StarSystem> ();
        for (int i = 0; i < numSystems; i++) {
            Systems.Add (new StarSystem (true));
        }
        Debug.Log ("Galaxy created");
    }

    // advances game time by given increment
    public void Step(int dDays=30) {

        // default to 30 day increment
        Day += dDays;
        onDayChanged?.Invoke (Day); 

        // update each StarSystem
        foreach(var ss in Systems) {
            ss.Step (dDays);
        }
    }

}
