using extOSC;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

namespace OSC.trans
{
    public class OSCIn2 : MonoBehaviour
    {
        private OSCTransmitter _transmitter;

        private OSCReceiver _receiver;

        private const string _oscAddress = "/scene";

        protected virtual void Start()
        {
            // Creating a transmitter.
            _transmitter = gameObject.AddComponent<OSCTransmitter>();

            // Set remote host address.
            _transmitter.RemoteHost = "127.0.0.1";

            // Set remote port;
            _transmitter.RemotePort = 7000;

            // Creating a receiver.
            _receiver = gameObject.AddComponent<OSCReceiver>();

            // Set local port.
            _receiver.LocalPort = 7002;

            // Bind "MessageReceived" method to special address.
            _receiver.Bind(_oscAddress, MessageReceived);
        }

        private void MessageReceived(OSCMessage scene)
        {
            Debug.Log(scene);
            var value = scene.Values[0].IntValue;
            if (value == 1)
            {
                SceneManager.LoadScene(1);
            }
            else if (value == 2)
            {
                SceneManager.LoadScene(2);
            }
            else if (value == 3)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
