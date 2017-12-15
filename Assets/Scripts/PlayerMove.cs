using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    GameObject gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameManager.GetComponent<SteamVRInputManager>().LStick.x, 0, gameManager.GetComponent<SteamVRInputManager>().LStick.y);
	}
}
