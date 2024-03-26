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
        private const string _posAddress = "/position";
        private const string _rotAddress = "/rotation";
        private const string _fadeAddress = "/fade";


        private string gID;
        private Vector3 newvectorPos;
        private Vector3 newvectorRot;
        private float fadeIn;
        public Transform newPos;
        public Material fadeMat;

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
            _receiver.Bind(_posAddress, ReceiveMessagePos);
            _receiver.Bind(_rotAddress, ReceiveMessageRot);
            _receiver.Bind(_fadeAddress, ReceiveMessageFade);
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

      
        
    
        private void ReceiveMessagePos(OSCMessage position)
        {
            //Debug.LogFormat("Received: {0}", position);
            newvectorPos.x = position.Values[0].FloatValue;
            newvectorPos.y = position.Values[1].FloatValue;
            newvectorPos.z = position.Values[2].FloatValue;
            newPos.localPosition = newvectorPos;
            Debug.Log(newvectorPos);
        }

        private void ReceiveMessageRot(OSCMessage rotation)
        {
            //Debug.LogFormat("Received: {0}", position);
            newvectorRot.x = rotation.Values[0].FloatValue;
            newvectorRot.y = rotation.Values[1].FloatValue;
            newvectorRot.z = rotation.Values[2].FloatValue;
            newPos.eulerAngles = newvectorRot;
            Debug.Log(newvectorRot);
        }

        private void ReceiveMessageFade(OSCMessage fade)
        {
            //Debug.LogFormat("Received: {0}", position);
            fadeIn = fade.Values[0].FloatValue;
            fadeMat.color = new Color (0, 0, 0, fadeIn);
            Debug.Log(newvectorRot);
        }

    }
}
