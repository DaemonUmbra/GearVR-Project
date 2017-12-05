using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVRInputManager : MonoBehaviour {
    public SteamVR_TrackedController LControl;
    public SteamVR_TrackedController RControl;
    public GameObject CameraRig;

	// Use this for initialization
	void Start () {
        //Gripped
        LControl.Gripped += LControl_Gripped;
        RControl.Gripped += RControl_Gripped;

        //Ungripped
        LControl.Ungripped += LControl_Ungripped;
        RControl.Ungripped += RControl_Ungripped;

        //TriggerClicked
        LControl.TriggerClicked += LControl_TriggerClicked;
        RControl.TriggerClicked += RControl_TriggerClicked;

        //TriggerUnclicked
        LControl.TriggerUnclicked += LControl_TriggerUnclicked;
        RControl.TriggerUnclicked += RControl_TriggerUnclicked;

        //PadTouched
        LControl.PadTouched += LControl_PadTouched;
        RControl.PadTouched += RControl_PadTouched;

        //PadUntouched
        LControl.PadUntouched += LControl_PadUntouched;
        RControl.PadUntouched += RControl_PadUntouched;

        //PadClicked
        LControl.PadClicked += LControl_PadClicked;
        RControl.PadClicked += RControl_PadClicked;

        //PadUnclicked
        LControl.PadUnclicked += LControl_PadUnclicked;
        RControl.PadUnclicked += RControl_PadUnclicked;
        
        //MenuButtonClicked
        LControl.MenuButtonClicked += LControl_MenuButtonClicked;
        RControl.MenuButtonClicked += RControl_MenuButtonClicked;

        //MenuButtonUnclicked
        LControl.MenuButtonUnclicked += LControl_MenuButtonUnclicked;
        RControl.MenuButtonUnclicked += RControl_MenuButtonUnclicked;

        //SteamClicked
        LControl.SteamClicked += LControl_SteamClicked;
        RControl.SteamClicked += RControl_SteamClicked;
	}

    private void RControl_MenuButtonUnclicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_MenuButtonUnclicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_MenuButtonClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_MenuButtonClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_SteamClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_SteamClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_PadUnclicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_PadUnclicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_PadUntouched(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_PadUntouched(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_PadClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_PadClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_PadTouched(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_PadTouched(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_TriggerUnclicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_TriggerUnclicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_TriggerClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_TriggerClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_Ungripped(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_Ungripped(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RControl_Gripped(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LControl_Gripped(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
