using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {
    public GameManager gameManager { get; private set; }

    public float GrabDistance = 1.5f;

    public Vector3 GunRotation = new Vector3(0, 0, -35);
    private Quaternion GunRot;

    //Hands
    public GameObject LHand;
    public GameObject RHand;

    //Glock
    public GameObject gun;
    public bool Firing = false;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        gun = GameObject.Find("Gun");
    }


    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Firing)
        {
            Debug.Log("Firing!");
            Fire();
        }
        else
        {
            gun.GetComponent<LineRenderer>().enabled = false;
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

    internal void AttemptRStopFire()
    {
        if (gun.transform.parent == RHand.transform)
        {
            Firing = false;
        }
    }

    internal void AttemptLStopFire()
    {
        if (gun.transform.parent == LHand.transform)
        {
            Firing = false;
        }
    }

    internal void AttemptRFire()
    {
        if (gun.transform.parent == RHand.transform)
        {
            Firing = true;
        }
    }

    internal void AttemptLFire()
    {
        if (gun.transform.parent == LHand.transform)
        {
            Firing = true;
        }
    }

    internal void AttemptRDrop()
    {
        if(gun.transform.parent == RHand.transform)
        {
            if (Firing)
            {
                Firing = false;
            }
            gun.transform.parent = null;
            gun.transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    internal void AttemptLDrop()
    {
        if (gun.transform.parent == LHand.transform)
        {
            if (Firing)
            {
                Firing = false;
            }
            gun.transform.parent = null;
            gun.transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    internal void AttemptRGrab()
    {
        if (gun.transform.parent == null)
        {
            if (Vector3.Distance(gun.transform.position, RHand.transform.position) <= GrabDistance)
            {
                gun.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.parent = RHand.transform;
                gun.transform.localPosition = Vector3.zero;
                gun.transform.localRotation = Quaternion.Euler(GunRotation);
            }
        }
    }

    internal void AttemptLGrab()
    {
        if (gun.transform.parent == null)
        {
            if (Vector3.Distance(gun.transform.position, LHand.transform.position) <= GrabDistance)
            {
                gun.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.parent = LHand.transform;
                gun.transform.localPosition = Vector3.zero;
                gun.transform.localRotation = Quaternion.Euler(GunRotation);
            }
        }
    }

    internal void ResetGun()
    {
        AttemptRDrop();
        AttemptLDrop();
        gun.transform.position = gameManager.OriginalGunPos;
        gun.transform.rotation = gameManager.OriginalGunRot;
    }

    internal void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
