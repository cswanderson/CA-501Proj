using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSpot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var aCts = SceneManager.GetActiveScene().ToString();
        if (aCts == "T2")
        {
            GameObject.Find("GR3D Player").GetComponent<Transform>().localPosition.Set(newX: 21, newY: 20, newZ: -264);
        }
    }
}
