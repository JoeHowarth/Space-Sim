using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy {
    /*
     * Top level data element for the game
     * Orchestrates 
     *   - setup
     *   - steps
     */
    static public Galaxy G { get; protected set; }
    public List<StarSystem> Systems;
    // list of nations
    public int Day { get; protected set; } = 0;// day of time

    public Galaxy (int numSystems = 1) {
        // set static instance
        if (G != null) {
            Debug.LogError ("Only 1 Galaxy allowed!");
        }
        G = this;

        Systems = new List<StarSystem> ();
        for (int i = 0; i < numSystems; i++) {
            Systems.Add (new StarSystem (true));
            //Debug.Log ("Sytem " + i + " added");
        }

    }

    // advances game time by given increment
    public void Step(int dDays=30) {
        // default to 30 day increment
        Day += dDays;

        // update each StarSystem
        foreach(var ss in Systems) {
            ss.Step (dDays);
        }
    }
}
