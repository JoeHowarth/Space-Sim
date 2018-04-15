using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCT : MonoBehaviour {
    SpriteRenderer sr;
    Vector2 spriteSize, cameraSize, scale;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer> ();

        mouseCT.cbCameraSize += FitBackground2Camera;
        spriteSize = sr.sprite.bounds.size;

        FitBackground2Camera (Camera.main.orthographicSize);
    }


    void FitBackground2Camera (float cameraOrthoSize) {
        float cameraHeight = cameraOrthoSize * 2;
        cameraSize = new Vector2 (Camera.main.aspect * cameraHeight, cameraHeight);

        scale = new Vector3 (1f, 1f, 0);
        if (cameraSize.x / cameraSize.y >= spriteSize.x / spriteSize.y) { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        } else { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        //Debug.Log ("FitBackground2Camera called");

        transform.localScale = scale;
    }
}
