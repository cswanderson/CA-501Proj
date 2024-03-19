
using extOSC;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SkyChange3 : MonoBehaviour
{

    private OSCReceiver _receiver;

    private const string _oscAddress = "/sbox"; // Also, you cam use mask in address: /example/*/

    public bool skyChange3;

    protected virtual void Start()
    {
        // Creating a receiver.
        _receiver = gameObject.AddComponent<OSCReceiver>();

        // Set local port.
        _receiver.LocalPort = 7003;

        // Bind "MessageReceived" method to special address.
        _receiver.Bind(_oscAddress, MessageReceived);
    }
    protected void MessageReceived(OSCMessage message)
    {
        
        Debug.Log(message);
        if (message.Values[0].IntValue == 1)
        {
            skyChange3 = true;
            
        }
        else { skyChange3 = false; }
      


    }
    public void Changesky3()
        {
   
        foreach (Camera item in Camera.allCameras)
        {
        item.clearFlags = CameraClearFlags.SolidColor;

        }
     
    }

    public void ChangeSkybox3()
    {
        foreach (Camera item in Camera.allCameras)
        {
            item.clearFlags = CameraClearFlags.Skybox;

        }

    }
private void Update()
    {
        if (skyChange3 == true)
        {
            Changesky3();
        }
     else
        {
            ChangeSkybox3();
        }
    }

}
