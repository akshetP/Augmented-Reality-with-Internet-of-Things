using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Networking;

public class ARwithIoT_Script : MonoBehaviour
{
    public VirtualButtonBehaviour VB_ON;
    public VirtualButtonBehaviour VB_OFF;
    public string URL_ON;
    public string URL_OFF;

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

        }
    }

    void Start()
    {
        VB_ON.RegisterOnButtonPressed(OnButtonPressed_on);

        VB_OFF.RegisterOnButtonPressed(OnButtonPressed_off);
       
    }


    public void OnButtonPressed_on(VirtualButtonBehaviour VB_ON)
    {
        StartCoroutine(GetRequest(URL_ON));
        Debug.Log("LED IS ON");
    }

    public void OnButtonPressed_off(VirtualButtonBehaviour VB_OFF)
    {
        StartCoroutine(GetRequest(URL_OFF));
        Debug.Log("LED IS OFF");
    }

}