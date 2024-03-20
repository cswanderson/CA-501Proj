using extOSC;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using Plugin = getReal3D.Plugin;

namespace OSC.trans
{
    public class OSCIn1 : MonoBehaviour
    
 
    
    {
        private OSCTransmitter _transmitter;

        private OSCReceiver _receiver;

        private const string _oscAddress = "/scene";

        private string gID;
        
        protected virtual void Start()
        {
            gID = Plugin.getClusterID().ToString();
            
            // Creating a transmitter.
            _transmitter = gameObject.AddComponent<OSCTransmitter>();

            // Set remote host address.
            _transmitter.RemoteHost = "127.0.0.1";

            // Set remote port;
            _transmitter.RemotePort = 7000;

            // Creating a receiver.
            _receiver = gameObject.AddComponent<OSCReceiver>();

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
            _receiver.Bind(_oscAddress, MessageReceived);
        }

        private void MessageReceived(OSCMessage scene)
        {
            Debug.Log(scene);
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
        }
    }
}
