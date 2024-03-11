using extOSC;
using Unity.VisualScripting;
using UnityEngine;

public class SceneChange : MonoBehaviour
{

    [SerializeField] public int ActiveScene;
    public void Trig1()
    {
        Variables.Application.Set("ActiveScene", 1);
        }
}
