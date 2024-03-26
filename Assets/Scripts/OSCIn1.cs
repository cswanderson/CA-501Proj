using System;
using extOSC;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Plugin = getReal3D.Plugin;

namespace OSC.trans
{
    public class OSCIn1 : MonoBehaviour

    {
        private OSCTransmitter _transmitter;

        private OSCReceiver _receiver;
        
        private const string _sceneAddress = "/scene";
        private const string _posXAddress = "/positionX";
        private const string _posYAddress = "/positionY";
        private const string _posZAddress = "/positionZ";

        private string gID;
        private float posX;
        private float posY;
        private float posZ;

        private Vector3 newvector;

        public void Start()
        {
            // Creating a transmitter.
            _transmitter = gameObject.AddComponent<OSCTransmitter>();

            // Set remote host address.
            _transmitter.RemoteHost = "127.0.0.1";

            // Set remote port;
            _transmitter.RemotePort = 7000;

            // Creating a receiver.
            _receiver = gameObject.AddComponent<OSCReceiver>();

            gID = Plugin.getClusterID().ToString();

            // Set local port.
            if (gID == "0")
            {
                _receiver.LocalPort = 7001;

            }
            else if (gID == "1")
            {
                _receiver.LocalPort = 7002;
            }

            if (gID == "2")
            {
                _receiver.LocalPort = 7003;
            }
            // Bind "MessageReceived" method to special address.
            _receiver.Bind(_sceneAddress, ReceiveMessageScene);
            _receiver.Bind(_posXAddress, ReceiveMessagePosX);
            _receiver.Bind(_posYAddress, ReceiveMessagePosY);
            _receiver.Bind(_posZAddress, ReceiveMessagePosZ);
            
           
        }

        private void ReceiveMessageScene(OSCMessage scene)
        {

            var value = scene.Values[0].IntValue;
            if (value == 0)
            {
                SceneManager.LoadScene(0);
            }
           else if (value == 1)
            { 
                SceneManager.LoadScene(1);
            }
            else if (value == 2)
            { 
                SceneManager.LoadScene(2);
            }
           
           Debug.LogFormat("Received: {0}", scene);

        }

      
        
        private void ReceiveMessagePosX(OSCMessage positionX)
        {
            var value = positionX.Values[0].IntValue;
            Debug.LogFormat("Received: {0}", positionX);
            var Gx = GameObject.Find("GR3D Player");

        }
        private void ReceiveMessagePosY(OSCMessage positionY)
        {
            Debug.LogFormat("Received: {0}", positionY);
            newvector.y = positionY.Values[0].FloatValue;
        }
        private void ReceiveMessagePosZ(OSCMessage positionZ)
        {
            Debug.LogFormat("Received: {0}", positionZ);
            newvector.z = positionZ.Values[0].FloatValue;
        }
    }
}
