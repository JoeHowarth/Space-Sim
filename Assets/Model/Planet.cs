using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Planet {
    public PType PlanetType { get; protected set; }
    public int ID { get; protected set; }
    public string PName { get; protected set; }
    public Physical Physical;
    public PlanetSystem PS;

    public virtual void Step(int dDays) {}

}

public class TerrestrialP : Planet {
    public TerrestrialP (PlanetSystem _ps, string name, Physical phys)
    {
        PName = name;
        PS = _ps;
        PlanetType = PType.Terrestrial;

        // set physical traits
        Physical = phys;
        //Physical.radius = _radius;
        //Physical.density = _density;
        //Physical.mass = (Mathf.PI * _radius * _radius * _radius * 4f) / 3f;

    }
}

public class GasGiantP : Planet {
    public GasGiantP (PlanetSystem _ps, string name, Physical phys)
    {
        PName = name;
        PS = _ps;
        PlanetType = PType.GasGiant;

        // set physical traits
        Physical = phys;
        //Physical.radius = _radius;
        //Physical.density = _density;
        //Physical.mass = (Mathf.PI * _radius * _radius * _radius * 4f) / 3f;



    }
}

public struct Physical { public float mass, radius, density; }

public enum PType { Terrestrial, GasGiant }
