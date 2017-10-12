using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

    // Use this for initialization
    private Vector3 originalGunPos;
    private bool gunInHand = false;
    private GameObject gun;
    private GameObject rightHand;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        
    }


    void Start () {
        gun = GameObject.Find("Gun");
        originalGunPos = gun.transform.position;
        rightHand = GameObject.Find("RightHandAnchor");
    }
	
	// Update is called once per frame
	void Update () {
        bool grabAttempt = false;
        bool shootAttempt = false;
        bool gunResetAttempt = false;
        bool levelResetAttempt = false;
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTouch)) //Oculus Touch
        {
            grabAttempt = (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0);
            shootAttempt = (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > .1f);
            gunResetAttempt = OVRInput.Get(OVRInput.Button.One);
            levelResetAttempt = OVRInput.Get(OVRInput.Button.Two);
        }
        else if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote)) //GearVR
        {
            grabAttempt = OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
            shootAttempt = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
            gunResetAttempt = OVRInput.Get(OVRInput.Button.DpadUp);
            levelResetAttempt = OVRInput.Get(OVRInput.Button.DpadDown);
        }
        GameObject.Find("DebugText").GetComponent<Text>().text = "Grip Input: " + OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger).ToString() + "\nDistance: " + Vector3.Distance(gun.transform.position, rightHand.transform.position);
        if (grabAttempt && (Vector3.Distance(gun.transform.position,rightHand.transform.position) <= .2f))
        {
            if (!gun.transform.IsChildOf(rightHand.transform))
            {
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.parent = rightHand.transform;
                gun.transform.localPosition = Vector3.zero;
                gun.transform.localRotation = Quaternion.identity;
                gunInHand = true;
            }
        }
        else
        {
            gun.transform.SetParent(null);
            gun.GetComponent<Rigidbody>().isKinematic = false;
            gunInHand = false;
        }
        if(shootAttempt && gunInHand && GetComponent<GameManager>().Seconds > 0)
        {
            Fire();
        }
        else
        {
            gun.GetComponent<LineRenderer>().enabled = false;
        }

        if (gunResetAttempt)
        {
            gun.transform.position = originalGunPos;
            gun.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (levelResetAttempt)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void Fire()
    {
            Ray ray = new Ray(GameObject.Find("Gun Socket").transform.position, GameObject.Find("Gun Socket").transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            gun.GetComponent<LineRenderer>().enabled = true;
            Vector3[] Points = new Vector3[] { ray.origin, hit.point };
            gun.GetComponent<LineRenderer>().SetPositions(Points);
            if (hit.collider.GetComponent<Hittable>())
            {
                hit.collider.GetComponent<Hittable>().Hit(hit,ray);
            }
        }
        else
        {
            gun.GetComponent<LineRenderer>().enabled = false;
        }
    }
}
