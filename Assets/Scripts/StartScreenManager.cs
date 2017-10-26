using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour {
    Transform rightHand;
    Transform gearVrController;
    LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        rightHand = GameObject.Find("RightHandAnchor").transform;
        gearVrController = GameObject.Find("GearVrController").transform;
        lineRenderer = gearVrController.GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = new Ray(gearVrController.position, gearVrController.GetChild(0).forward);
        lineRenderer.SetPosition(0, rightHand.position);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1,rightHand.position + (10 * ray.direction));
        }

        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && hit.transform.gameObject == GameObject.Find("Button"))
        {
            StartGame();
        }
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && hit.transform.gameObject == GameObject.Find("Quit"))
        {
            Application.Quit();
        }
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Test Scene");
    }
}
