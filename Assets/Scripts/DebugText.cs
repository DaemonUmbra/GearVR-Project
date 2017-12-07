using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {
    SteamVRInputManager SVRManager;
    public string TextToPrint = "";
	// Use this for initialization
	void Start () {
        SVRManager = GameObject.Find("GameManager").GetComponent<SteamVRInputManager>();

    }
	
	// Update is called once per frame
	void Update () {
        TextToPrint = "LStick: " + SVRManager.LStick + "   RStick: " + SVRManager.RStick; 
        gameObject.GetComponent<Text>().text = TextToPrint;
	}
}
