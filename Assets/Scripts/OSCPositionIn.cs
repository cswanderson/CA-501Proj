using System;
using extOSC;
using OSC.trans;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using Plugin = getReal3D.Plugin;

public class OSCPositionIn : MonoBehaviour
{
    private const string _oscAddress = "/position";
    
    protected virtual void Start()
    {

    }
    private void MessageReceived(OSCMessage position)
    {
        Debug.LogFormat("Received: {0}", position);
    }
}
