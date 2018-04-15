using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystemCT : MonoBehaviour {

    public Sprite Planet_Sprite;
    public PlanetSystem PS;

	// Use this for initialization
    public void Init (PlanetSystem _ps) {
        
        PS = _ps; // assign parent planet System
        gameObject.name = PS.PName + "_view"; // set unity obj name


        // fetch planet sprite and set sprite
        Planet_Sprite = Resources.Load<Sprite> ("planet/" + PS.PName);
        SpriteRenderer sr = GetComponent<SpriteRenderer> ();
        sr.sprite = Planet_Sprite;

        // set initial visual position and size of planet
        //transform.localPosition = new Vector3 (PS.orbit.radius / 5e5f, 0,0);
        transform.localPosition = PS.Pos / 5e5f;
        float scale = Mathf.Sqrt(PS.planet.Physical.radius) / 5f;
        transform.localScale = new Vector3 (scale, scale,0);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log ("in PSCT update " + PS.PName);
        transform.localPosition = PS.Pos / 5e5f;
	}
}
