using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem {
    /*
     * Setup for Sol currently
     */
    public List<PlanetSystem> planetSystems;
    public string Name { get; protected set; }
    public int NumPlanets {
        get { return planetSystems.Count; }
    }

    public StarSystem (bool sol = true) {
        if (sol) {
            CreateSol ();
        } else {
            Debug.LogError ("non-sol systyems not implemented");
            CreateSol ();
        }
    }

    public void Step(int dDays) {
        // step for System

        // step for each PS
        foreach (var PS in planetSystems) {
            PS.Step (dDays);
        }
    }

    void CreateSol () {
        var sf = new SF (true);
        Name = "Sol";
        planetSystems = new List<PlanetSystem>();
        Debug.Log ("In CreateSol");
        for (int i = 0; i < SF.names.Length; i++) {

            PlanetSystem ps = new PlanetSystem (SF.names [i], SF.phys [i], SF.orbits [i], SF.pType [i]);
            planetSystems.Add (ps);
        }
    }

}

public struct SF {
    public SF (bool t) {
        sunMass = 1.989e30f;
        mu = 1.32712438e11f;
        names = new string [] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };

        phys = new Physical [8];
        phys [0].radius = 2440f; //mercury
        phys [0].mass = 3.30e23f;
        phys [1].radius = 6052f; // venus
        phys [1].mass = 4.77e24f;
        phys [2].radius = 6378f; // earth
        phys [2].mass = 5.97e24f;
        phys [3].radius = 3387f; // mars
        phys [3].mass = 6.42e23f;

        phys [4].radius = 71492f; //jupyter
        phys [4].mass = 1.90e27f;
        phys [5].radius = 69268f; // saturn
        phys [5].mass = 5.68e26f;
        phys [6].radius = 25559f; // urnanus
        phys [6].mass = 8.68e25f;
        phys [7].radius = 24766f; // neptune
        phys [7].mass = 1.02e26f;



        orbits = new Orbit_PS [8];
        orbits [0].radius = 57.9e6f;
        orbits [1].radius = 106.2e6f;
        orbits [2].radius = 149.6e6f;
        orbits [3].radius = 228.9e6f;
        orbits [4].radius = 778e6f;
        orbits [5].radius = 1433e6f;
        orbits [6].radius = 2872e6f;
        orbits [7].radius = 4495e6f;

        pType = new bool [8];
        //float pi2 = 4f * Mathf.PI * Mathf.PI;
        for (int i = 0; i < 8; i++) {
            pType [i] = i < 4;
            orbits [i].mass = phys [i].mass;
            orbits [i].init ();
            //orbits [i].period_s = Mathf.Sqrt (pi2 * Mathf.Pow (orbits [i].radius, 3) / mu);
        }

    }

    public static float sunMass, mu;
    public static Orbit_PS [] orbits;
    public static bool [] pType;
    public static string [] names;
    public static Physical [] phys;
}

public enum PNames_Sol {
    Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
}