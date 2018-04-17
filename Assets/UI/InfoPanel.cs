using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InfoPanel : MonoBehaviour {

    Text dayCount;
    public GameObject TextObPrefab;

	void Start () {
        //var dcGO = new GameObject ("Day Count", new Type [] { typeof(Text), typeof(RectTransform), typeof(CanvasRenderer) });
        var dcGO = Instantiate<GameObject> (TextObPrefab, transform);
        dayCount = dcGO.GetComponent<Text> ();

        var tmp = setTextcbFactory<int> (dayCount, "Day Count: ");
        tmp (0);
        //Galaxy.G.RegisterDayChanged ((int i) =>  tmp(i.ToString ()));
        Galaxy.G.RegisterDayChanged ( tmp ); 



    }
	
	void Update () {
		
	}

    static public Action<T> setTextcbFactory<T>(Text text, string lhs = "") {
        return (T t) => text.text = lhs + t;
    }

    //static public GameObject SpawnTextObject(string base_text, Transform parent,  {
    //    var dcGO = new GameObject ("Day Count", new Type [] { typeof (Text) });
    //    dcGO.transform.SetParent (parent);

    //    dayCount = dcGO.GetComponent<Text> ();
    //    dayCount.font = Resources.GetBuiltinResource<Font> ("Arial.ttf");
    //}
}
