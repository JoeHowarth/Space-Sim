using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mouseCT : MonoBehaviour {

    static public Vector3 currPos;
    Vector3 lastPos;
    public static Action<float> cbCameraSize; 

	// Use this for initialization
	void Start () {
        lastPos = currPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	  
	// Update is called once per frame
	void Update () { 
        currPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        // move map by dragging
        if (Input.GetMouseButton (1)) {
            var diff = lastPos - currPos;
            Camera.main.transform.localPosition += diff;
        }


        // 
        var dScroll = Input.mouseScrollDelta.y;
        if (dScroll >= 0.1f || dScroll <= -0.1f) {
            Camera.main.orthographicSize *= 1.0f + dScroll * 0.05f;
            cbCameraSize?.Invoke (Camera.main.orthographicSize);
        }


        lastPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

	}
}
