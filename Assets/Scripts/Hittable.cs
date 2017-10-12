using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hittable : MonoBehaviour {
    bool validTarget = true;
    private Vector3 origPos;
    private Quaternion origRot;
    private float hitTime;

    private void Awake()
    {
        origPos = gameObject.transform.position;
        origRot = gameObject.transform.rotation;
    }

    private void Update()
    {
        ResetHittable();
    }
    public virtual void Hit(RaycastHit hit, Ray ray)
    {
        if (validTarget)
        {
            hitTime = Time.time;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().score++;
            validTarget = false;
        }
    }
    public virtual void ResetHittable()
    {
        if (Time.time - hitTime > .5)
        {
            if (Time.time - hitTime > 2 || Vector3.Distance(gameObject.transform.position, origPos) < .2f)
            {
                gameObject.transform.position = origPos;
                gameObject.transform.rotation = origRot;
                if (gameObject.GetComponent<Rigidbody>())
                {
                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                validTarget = true;
            }
        }
    }
}
