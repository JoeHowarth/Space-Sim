using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCT : MonoBehaviour {

    public static MainCT inst { get; protected set; }
    public static Galaxy Galaxy { get; protected set; }
    public static StarSystem Focus { get; set; }

    public GameObject SS_Prefab; // StarSystem prefab
    GameObject SS_OB;

    // Use this for initialization
    void Awake () {
        if (inst != null) {
            Debug.LogError ("Only 1 instance of GlaxyCT allowed!!");
        }
        inst = this;

        Galaxy = new Galaxy (1);
        Focus = Galaxy.Systems [0];
        SS_OB = Instantiate (SS_Prefab, gameObject.transform);

    }

    // Update is called once per frame
    void Update () {
        //Debug.Log ("in MainCT update");
        //Galaxy.Step (1);
    }

    public void GStep (int dTime = 1) {
        Galaxy.Step (dTime);
        Debug.Log ("GStep called with " + dTime);
    }
}
