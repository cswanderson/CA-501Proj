using extOSC;
using UnityEngine;
using Unity.VisualScripting;

namespace OSC.trans
{
    public class OSCIn : MonoBehaviour
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
            _receiver.LocalPort = 7001;

            // Bind "MessageReceived" method to special address.
            _receiver.Bind(_oscAddress, MessageReceived);
        }

        public void MessageReceived(OSCMessage scene)
        {
            Debug.Log(scene);
            var value = scene.Values[0].IntValue;
            Variables.Application.Set("scene", value);
          
        }

    }
}
