using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour {
    Transform rightHand;
    LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        rightHand = GameObject.Find("RightHandAnchor").transform;
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = new Ray(rightHand.position, rightHand.forward);
        lineRenderer.SetPosition(0, rightHand.position);
        lineRenderer.SetPositions(null);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1,rightHand.position + (2 * ray.direction));
        }

        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && hit.transform.gameObject == GameObject.Find("Button"))
        {
            StartGame();
        }
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Test Scene");
    }
}
