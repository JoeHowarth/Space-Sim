using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ToolTip : MonoBehaviour {
    // hover over tooltip to display data under cursor
    public GameObject TextPrefab;

    Dictionary<string, GameObject> fields;
    Dictionary<string, Text> texts;
    RaycastHit2D hit;


    // Use this for initialization
    void Start () {
        fields = new Dictionary<string, GameObject> ();
        texts = new Dictionary<string, Text> ();

        var type = Instantiate (TextPrefab, transform);
        type.name = "Type - Field";
        fields ["Type"] = type;
        texts ["Type"] = type.GetComponent<Text> ();

    }

    // Update is called once per frame
    void Update () {

        var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        transform.position = Input.mousePosition + Vector3.one * 5;

        hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
        if (hit.collider != null) {
            //Debug.Log (hit.transform.tag);
            texts ["Type"].text = hit.transform.tag;
        } else {
            texts ["Type"].text = " ";
        }

    }
}
