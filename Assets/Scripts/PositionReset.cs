using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour {

    private Vector3 originalPos;
    // Use this for initialization
    void Start () {
        originalPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(gameObject.transform.position, originalPos) > 100){
            gameObject.transform.position = originalPos;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}

}
