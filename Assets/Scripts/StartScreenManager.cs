using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour {
    public Transform rightHand;
    Transform VrController;
    LineRenderer lineRenderer;
    SteamVR_TrackedController RController;
    bool TriggerPressed = false;


	// Use this for initialization
	void Start () {
        //rightHand = GameObject.Find("Controller (right)").transform;
        VrController = rightHand;
        lineRenderer = VrController.GetComponent<LineRenderer>();
        RController = VrController.GetComponent<SteamVR_TrackedController>();
        RController.TriggerClicked += RController_TriggerClicked;
        RController.TriggerUnclicked += RController_TriggerUnclicked;
    }

    private void RController_TriggerUnclicked(object sender, ClickedEventArgs e)
    {
        TriggerPressed = false;
    }

    private void RController_TriggerClicked(object sender, ClickedEventArgs e)
    {
        TriggerPressed = true;
    }

    // Update is called once per frame
    void Update () {

        RaycastHit hit;
        Ray ray = new Ray(VrController.position, VrController.GetChild(0).forward);
        lineRenderer.SetPosition(0, rightHand.position);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1,rightHand.position + (10 * ray.direction));
        }

        if(TriggerPressed && hit.transform.gameObject == GameObject.Find("Button"))
        {
            StartGame();
        }
        if(TriggerPressed && hit.transform.gameObject == GameObject.Find("Quit"))
        {
            Application.Quit();
        }
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Test Scene");
    }
}
