using System;
using System.Collections;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Plugin = getReal3D.Plugin;

public class SceneChanger : MonoBehaviour
{
    private string gID;
    public string Scene1Name = "T1";
    public string Scene2Name = "T2";
    public string Scene3Name = "T3";
    public float LaunchStart = 15.0f;
    public float LaunchScene1 = 101.88f;
    public float LaunchScene3A = 176.6f;
    public float LaunchScene2 = 208.3f;
    public float LaunchScene3B = 281.88f;
    private float fadeIn = 3f;
    private float fadeOut;
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

    public float fadeDur = 3.0f;

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
    void Start()
    {
        GetStars();
        StartCoroutine(WaitAndChangeScene1(LaunchScene1));
        StartCoroutine(WaitAndChangeScene3A(LaunchScene3A));
        StartCoroutine(WaitAndChangeScene2(LaunchScene2));
        StartCoroutine(WaitAndChangeScene3B(LaunchScene3B));
        gID = Plugin.getClusterID().ToString();
 
    }
    private void GetStars()
    {
        sTars = GameObject.Find("StarClusteReg");
        cSatRend = sTars.GetComponent<Renderer>();
        cSatMat = cSatRend.material;
        bigC = GameObject.Find("BigC_prefab");
    }
    private void Fadein1()
    {
        fadeMat.color = new Color(0, 0, 0, Time.deltaTime % 100.0f / fadeIn);
    }

IEnumerator WaitAndChangeScene1(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Scene1Name);
        Fadein1();  
    }

        IEnumerator WaitAndChangeScene3A(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Scene3Name);
    }

    IEnumerator WaitAndChangeScene2(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Scene2Name);
    }

    IEnumerator WaitAndChangeScene3B(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Scene3Name);
    }
}
