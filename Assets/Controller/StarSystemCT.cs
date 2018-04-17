using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class StarSystemCT : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {

    StarSystem Star;
    GameObject [] PSObs;
    PlanetSystemCT [] PSCTs;
    int numPlanets;

    public void OnPointerDown (PointerEventData eventData) {
        Debug.Log ("down on Star");
    }

    public void OnPointerEnter (PointerEventData eventData) {
        Debug.Log ("entered on Star");
    }


    // Use this for initialization
    void Start () {

        // the StarSystem that data comes from
        Star = MainCT.Focus;
        numPlanets = Star.NumPlanets; // Change to variable number
        gameObject.name = Star.Name + "_view"; // set Unity obj name
        transform.localScale = new Vector3 (50, 50); // size

        // initialize object and controller arrays
        PSObs = new GameObject [numPlanets];
        PSCTs = new PlanetSystemCT [numPlanets];

        // spawn planet controllers for StarSystem
        for (int i = 0; i < numPlanets; i++) {

            // create obj w/ components
            GameObject PSobj = new GameObject ();
            PSobj.AddComponent<SpriteRenderer> ();
            PSobj.AddComponent<PlanetSystemCT> ();
            PSobj.AddComponent<CircleCollider2D> ();
            PSobj.tag = "Planet";

            PSobj.transform.SetParent (transform.parent, true);

            // Init PS controller
            var CT = PSobj.GetComponent<PlanetSystemCT> ();
            CT.Init (Star.planetSystems [i]);

            // store in obj and CT arrays
            PSObs [i] = PSobj;
            PSCTs [i] = CT;
        }
    }

    // Update is called once per frame
    void Update () {

    }


}
