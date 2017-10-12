using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHittable : Hittable {

    public float force = 10f;

    public override void Hit(RaycastHit hit, Ray ray)
    {
        base.Hit(hit, ray);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
    }

    // Use this for initialization
    void Start () {
        if (!gameObject.GetComponent<Rigidbody>())
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        ResetHittable();
	}
}
