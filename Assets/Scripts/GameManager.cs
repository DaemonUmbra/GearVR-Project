using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int score = 0;
    public int Hours = 0;
    public int Minutes = 2;
    public float Seconds = 0;
    public UIController uiCont;
    public Vector3 OriginalGunPos { get; private set; }
    public Quaternion OriginalGunRot { get; private set; }

    public GameObject Gun { get; private set; }
	// Use this for initialization
	void Start () {
        Gun = GameObject.Find("Gun");
        for(int i = 0;i< Gun.transform.childCount;i++)
        {
            Physics.IgnoreCollision(Gun.transform.GetChild(i).GetComponent<Collider>(), gameObject.GetComponent<SteamVRInputManager>().CameraRig.GetComponent<Collider>());
        }
        uiCont = gameObject.GetComponent<UIController>();
        Minutes += Hours * 60;
        Seconds += Minutes * 60;
        OriginalGunPos = GameObject.Find("Gun").transform.position;
        OriginalGunRot = GameObject.Find("Gun").transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        Seconds = Seconds - Time.deltaTime;
        if(Seconds < 0) { Seconds = 0; }
        if (uiCont)
        {
            if (Seconds > 0)
            {
                uiCont.SetTime(Seconds.ToString("F2"));
                uiCont.SetScore(score.ToString());
            }
            else
            {
                if(score >= 10)
                {
                    uiCont.SetWin();
                    SceneManager.LoadScene(2);
                }
                else
                {
                    uiCont.SetLose();
                    SceneManager.LoadScene(3);
                }
            }
        }
	}
}
