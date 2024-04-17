using System;
using System.Collections.Generic;
using extOSC;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Plugin = getReal3D.Plugin;


namespace OSC.trans
{
    public class OSCIn1 : MonoBehaviour

    {
        [SerializeField] private List<AudioSource> allMusicSources;
        
        private OSCTransmitter _transmitter;

        private OSCReceiver _receiver;
        
        private const string _sceneAddress = "/scene";
        private const string _playAddress = "/play";
        private const string _posAddress = "/position";
        private const string _rotAddress = "/rotation";
        private const string _fadeAddress = "/fade";
        private const string _cSatAddress = "/color_saturation";
        private const string _cMultAddress = "/Size_Mult";
        private const string _cVarsAddress = "/Var_Shift";
        private const string _cTwinkAddress = "/use_twinkle";
        private const string _cTwinkSpAddress = "/twinkle_speed";
        private const string _cTwinkStAddress = "/twinkle_strength";
        private const string _cMinScreenAddress = "/min_screen_size";
        private const string _windDCarAddress = "/Wind_DirectionCar";
        private const string _windPCarAddress = "/Wind_PowerCar";
        private const string _CarPosAddress = "/CarPosition";
        private const string _CarRotAddress = "/CarRotation";

        private string gID;
        private Vector3 newvectorPos;
        private Vector3 newvectorRot;
        private float fadeIn;
        public Transform newPos;
        public Material fadeMat;
        private Material cSatMat;
        private GameObject sTars;
        private GameObject bigC;
        private float saturation;
        private float sizeMult;
        private float varShift;
        private float uTwink;
        private float twinkSp;
        private float twinkSt;
        private float minScreen;
        private float wPowCar;
        private Vector3 wDirCar;
        private Vector3 carPos;
        private Vector3 carRot;
        private Renderer cSatRend;
        private float mPlay;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex == 0)
            {
            GetStars();
        }
        }
        public void Start()
        {
           GetStars();
            

            //wDirCarx = GameObject.Find("BigC_prefab").GetComponent<FMPCHelper>().windDirection.x;
            //wDirCary = GameObject.Find("BigC_prefab").GetComponent<FMPCHelper>().windDirection.y;
            //wDirCary = GameObject.Find("BigC_prefab").GetComponent<FMPCHelper>().windDirection.z;

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
            _receiver.Bind(_cSatAddress, ReceiveMessageSat);
            _receiver.Bind(_cMultAddress, ReceiveMessageMult);
            _receiver.Bind(_cVarsAddress, ReceiveMessageVarS);
            _receiver.Bind(_cTwinkAddress, ReceiveMessageTwink);
            _receiver.Bind(_cTwinkSpAddress, ReceiveMessageTwinkSp);
            _receiver.Bind(_cTwinkStAddress, ReceiveMessageTwinkSt);
            _receiver.Bind(_cMinScreenAddress, ReceiveMessageMinScreen);
            _receiver.Bind(_windDCarAddress, ReceiveMessageWindDCar);
            _receiver.Bind(_windPCarAddress, ReceiveMessageWindPCar);
            _receiver.Bind(_CarPosAddress, ReceiveMessageCarPos);
            _receiver.Bind(_CarRotAddress, ReceiveMessageCarRot);
            _receiver.Bind(_playAddress, ReceiveMessagePlay);
        }

     

        private void GetStars()
        {
            sTars = GameObject.Find("StarClusteReg");
            cSatRend = sTars.GetComponent<Renderer>();
            cSatMat = cSatRend.material;
            bigC = GameObject.Find("BigC_prefab");
        }
        
        private void ReceiveMessagePlay(OSCMessage play)
        {
            Debug.Log("Test");
            var value = play.Values[0].IntValue;
            if (value == 1)
            {
                foreach (AudioSource source in allMusicSources)
                {
                    source.Play();
                }
            }
            if (value == 0)
            {
                foreach (AudioSource source in allMusicSources)
                {
                    source.Stop();
                }
            }
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
            newvectorPos.x = position.Values[0].FloatValue;
            newvectorPos.y = position.Values[1].FloatValue;
            newvectorPos.z = position.Values[2].FloatValue;
            newPos.localPosition = newvectorPos;
        }

        private void ReceiveMessageRot(OSCMessage rotation)
        {
            newvectorRot.x = rotation.Values[0].FloatValue;
            newvectorRot.y = rotation.Values[1].FloatValue;
            newvectorRot.z = rotation.Values[2].FloatValue;
            newPos.eulerAngles = newvectorRot;
        }

        private void ReceiveMessageFade(OSCMessage fade)
        {
            fadeIn = fade.Values[0].FloatValue;
            fadeMat.color = new Color (0, 0, 0, fadeIn);
            
        }
        private void ReceiveMessageSat(OSCMessage sat)
        {
            saturation = sat.Values[0].FloatValue;
            cSatMat.SetFloat("_Color_Saturation", saturation);
       
        }
        private void ReceiveMessageMult(OSCMessage mult)
        {
            
            sizeMult = mult.Values[0].FloatValue;
            cSatMat.SetFloat("_Size_Multiplier", sizeMult);
       

        }
        private void ReceiveMessageVarS(OSCMessage varS)
        {
            varShift = varS.Values[0].FloatValue;
            cSatMat.SetFloat("_Variation_Shift", varShift);
        }
        private void ReceiveMessageTwink(OSCMessage twink)
        {
            uTwink = twink.Values[0].FloatValue;
            cSatMat.SetFloat("_Use_Twinkle", uTwink);
        }
        private void ReceiveMessageTwinkSp(OSCMessage twinkSpe)
        {
            twinkSp = twinkSpe.Values[0].FloatValue;
            cSatMat.SetFloat("_Twinkle_Speed", twinkSp);
        }

        private void ReceiveMessageTwinkSt(OSCMessage twinkStr)
        {
            twinkSt = twinkStr.Values[0].FloatValue;
            cSatMat.SetFloat("_Twinkle_Strength", twinkSt);
        }
        private void ReceiveMessageMinScreen(OSCMessage minScr)
        {
            minScreen = minScr.Values[0].FloatValue;
            cSatMat.SetFloat("_Minimum_Screen_Size", minScreen);
        }

        private void ReceiveMessageWindDCar(OSCMessage winDCar)
        {
            wDirCar.x = winDCar.Values[0].FloatValue;
            wDirCar.y = winDCar.Values[1].FloatValue;
            wDirCar.z = winDCar.Values[2].FloatValue;
            bigC.GetComponent<FMPCHelper>().windDirection = wDirCar;
        }

        private void ReceiveMessageWindPCar(OSCMessage winPCar)
        {
            wPowCar = winPCar.Values[0].FloatValue;

            bigC.GetComponent<FMPCHelper>().windPower = wPowCar;

        }

        private void ReceiveMessageCarPos(OSCMessage CarPos)
        {
            carPos.x = CarPos.Values[0].FloatValue;
            carPos.y = CarPos.Values[1].FloatValue;
            carPos.z = CarPos.Values[2].FloatValue;
            bigC.transform.localPosition = carPos;
        }

        private void ReceiveMessageCarRot(OSCMessage CarRot)
        {
            carRot.x = CarRot.Values[0].FloatValue;
            carRot.y = CarRot.Values[1].FloatValue;
            carRot.z = CarRot.Values[2].FloatValue;
            bigC.transform.localEulerAngles = carRot;
        }
    }
}
