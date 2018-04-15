using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;

public class PlanetSystem {
    /*
     *  Models orbital motion for planet and 
     */
    public Orbit_PS orbit;
    public Planet planet;
    public string PName {
        get { return planet.PName; }
    }
    public Vector3 Pos { get; protected set; }


    public PlanetSystem (string name, Physical planetPhys, Orbit_PS o, bool terrestrial) {
        orbit = o;
        if (!terrestrial) {
            planet = new GasGiantP (this, name,  planetPhys);
        } else {
            planet = new TerrestrialP (this, name, planetPhys);
        }

        // initialize position
        orbit.initTheta = Random.Range (0f, 2 * Mathf.PI);
        Pos = orbit.PosAtTime (0);

        if (PName == "Earth") {
            Debug.Log (orbit.PosAtTime (0) + " " + orbit.PosAtTime (30));
            Debug.Log (orbit.period_d);
        }
    }

    public void Step(int dTime) {
        Pos = orbit.PosAtTime (Galaxy.G.Day);
        
    }

    //public PlanetSystem (bool terrestrial)
    //{
    //    if (!terrestrial) {
    //        planet = new GasGiantP ();
    //        orbit.radius = Random.Range (800e6f, 4000e6f);
    //        orbit.mass = Rand.PowerRange (5e26f, 2e27f);
    //    } else {
    //        orbit.radius = Random.Range (50e6f, 400e6f);
    //    }

    //}
}

public struct Orbit_PS { 
    public float radius, mass, period_d, period_s, vel_mag, initTheta;
    public double period_sd;

    public void init() {
        double pi2 = 4 * PI * PI;
        period_sd = Sqrt (pi2 * Pow (radius, 3) / SF.mu); // in sec?
        period_s = (float)period_sd;
        period_d = period_s / (60f * 60f * 24f); // period in days
        vel_mag = Mathf.Sqrt (SF.mu / radius);
        initTheta = 0f;
    }

    public Orbit_PS (float r, float m, float ang=0) {
        radius = r;
        mass = m;
        float pi2 = 4f * Mathf.PI * Mathf.PI;
        period_sd = Sqrt (pi2 * Pow (radius, 3) / SF.mu); // in sec?
        period_s = (float)period_sd;
        period_d = period_s / (60f * 60f * 24f); // period in days
        vel_mag = Mathf.Sqrt (SF.mu / r);
        initTheta = ang;
    }

    /// <summary>
    /// Positions after dT days from start
    /// </summary>
    /// <returns>Current position</returns>
    /// <param name="dT">Time in days after game start</param>
    public Vector3 PosAtTime(float dT) {
        float theta = ((dT % period_d) / period_d) * 2 * Mathf.PI;
        theta = (theta + initTheta) % (2 * Mathf.PI);
        return PosAtTheta (theta);
    }

    public Vector3 PosAtTheta (float theta) {
        return new Vector3 (Mathf.Cos (theta), Mathf.Sin (theta), 0) * radius;
    }

}