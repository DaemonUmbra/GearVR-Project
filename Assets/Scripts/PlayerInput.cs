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
    public Transform rightHand;
    public Transform leftHand;
    public Transform Rig;

    bool grabAttempt = false;
    bool shootAttempt = false;
    bool gunResetAttempt = false;
    bool levelResetAttempt = false;
    bool gripattempt = false;
    float ForeAccel = 0;
    float LeftAccel = 0;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        
    }


    void Start () {
        gun = GameObject.Find("Gun");
        originalGunPos = gun.transform.position;
        SteamVR_TrackedController Controller = rightHand.GetComponent<SteamVR_TrackedController>();
        SteamVR_TrackedController LController = leftHand.GetComponent<SteamVR_TrackedController>();
        Controller.Gripped += Controller_Gripped;
        Controller.Ungripped += Controller_Ungripped;
        Controller.TriggerClicked += Controller_TriggerClicked;
        Controller.TriggerUnclicked += Controller_TriggerUnclicked;
        Controller.PadTouched += Controller_PadTouched;
        Controller.PadUntouched += Controller_PadUntouched;
        LController.PadTouched += LController_PadTouched;
        LController.PadUntouched += LController_PadUntouched;
    }

    private void LController_PadUntouched(object sender, ClickedEventArgs e)
    {
        Rig.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void LController_PadTouched(object sender, ClickedEventArgs e)
    {
        ForeAccel = e.padY;
        LeftAccel = e.padX;
        Rig.GetComponent<Rigidbody>().velocity = new Vector3(LeftAccel, 0, ForeAccel);
    }

    private void Controller_PadUntouched(object sender, ClickedEventArgs e)
    {
        gunResetAttempt = false;
        levelResetAttempt = false;
    }

    private void Controller_PadTouched(object sender, ClickedEventArgs e)
    {
        if(e.padY > 0)
        {
            gunResetAttempt = true;
            levelResetAttempt = false;
        }
        else
        {
            levelResetAttempt = true;
            gunResetAttempt = false;
        }
    }

    private void Controller_TriggerUnclicked(object sender, ClickedEventArgs e)
    {
        shootAttempt = false;
    }

    private void Controller_TriggerClicked(object sender, ClickedEventArgs e)
    {
        shootAttempt = true;
    }

    private void Controller_Ungripped(object sender, ClickedEventArgs e)
    {
        gripattempt = false;
    }

    private void Controller_Gripped(object sender, ClickedEventArgs e)
    {
        gripattempt = true;
    }

    // Update is called once per frame
    void Update () {

        //if (OVRInput.IsControllerConnected(OVRInput.Controller.RTouch)) //Oculus Touch
        //{
        //    grabAttempt = (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0);
        //    shootAttempt = (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > .1f);
        //    gunResetAttempt = OVRInput.Get(OVRInput.Button.One);
        //    levelResetAttempt = OVRInput.Get(OVRInput.Button.Two);
        //}
        //else if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote)) //GearVR
        //{
        //    grabAttempt = OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
        //    shootAttempt = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
        //    gunResetAttempt = OVRInput.Get(OVRInput.Button.DpadUp);
        //    levelResetAttempt = OVRInput.Get(OVRInput.Button.DpadDown);
        //}
        GameObject.Find("DebugText").GetComponent<Text>().text = "Grip Input: " + gripattempt + "\nDistance: " + Vector3.Distance(gun.transform.position, rightHand.transform.position);
        if (gripattempt && (Vector3.Distance(gun.transform.position,rightHand.transform.position) <= .2f))
        {
            if (!gun.transform.IsChildOf(rightHand.transform))
            {
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.parent = rightHand.transform;
                gun.transform.localPosition = Vector3.zero;
                gun.transform.localRotation = Quaternion.Euler(new Vector3(55, 0, 0));
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
            SceneManager.LoadScene("Start Scene");
            levelResetAttempt = false;
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
