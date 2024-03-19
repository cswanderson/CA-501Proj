
using extOSC;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SkyChange1 : MonoBehaviour
{

    private OSCReceiver _receiver;

    private const string _oscAddress = "/sbox"; // Also, you cam use mask in address: /example/*/

    public bool skyChange1;

    protected virtual void Start()
    {
        // Creating a receiver.
        _receiver = gameObject.AddComponent<OSCReceiver>();

        // Set local port.
        _receiver.LocalPort = 7001;

        // Bind "MessageReceived" method to special address.
        _receiver.Bind(_oscAddress, MessageReceived);
    }
    protected void MessageReceived(OSCMessage message)
    {
        
        Debug.Log(message);
        if (message.Values[0].IntValue == 1)
        {
            skyChange1 = true;
            
        }
        else { skyChange1 = false; }
      


    }
    public void Changesky1()
        {
   
        foreach (Camera item in Camera.allCameras)
        {
        item.clearFlags = CameraClearFlags.SolidColor;

        }
     
    }

    public void ChangeSkybox1()
    {
        foreach (Camera item in Camera.allCameras)
        {
            item.clearFlags = CameraClearFlags.Skybox;

        }

    }
private void Update()
    {
        if (skyChange1 == true)
        {
            Changesky1();
        }
     else
        {
            ChangeSkybox1();
        }
    }

}
