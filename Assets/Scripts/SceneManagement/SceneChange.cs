using extOSC;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] private int scene;
    
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(scene);
    }
}
