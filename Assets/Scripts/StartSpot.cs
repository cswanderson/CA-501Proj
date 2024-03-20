using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSpot : MonoBehaviour
{
    private string sceneName;


    private void SCheck()
    {
        if (sceneName == "T1")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localPosition.Set(newX: 58, newY: 31, newZ: 87);
        }

        else if (sceneName == "T2")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localPosition.Set(newX: 21, newY: 61, newZ: 254);
        }
        else if (sceneName == "T3")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localPosition.Set(newX: 21, newY: 61, newZ: 254);
        }
    }


    //void Awake()
   // {
       // var scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene is '" + scene.name + "'.");
       // sceneName = scene.name;
       // SCheck();
    //}

    //void OnSceneLoaded (Scene scene, LoadSceneMode mode)
   //{
    //  sceneName = scene.name;

      // Debug.Log("OnSceneLoaded: " + scene.name.ToString());
       //Debug.Log(mode);

        //if (SceneManager.GetActiveScene().isLoaded == true)
       //{
            //SCheck();
        //}
    //}

}
