

using UnityEngine;

public class SkyChanger : MonoBehaviour
{
    [SerializeField] bool skyChange;

    private static void ChangeSky()
    {
        foreach (Camera item in Camera.allCameras)
        {
            item.clearFlags = CameraClearFlags.SolidColor;
        }
    }

    private static void ChangeSkybox()
    {
        foreach (Camera item in Camera.allCameras)
        {
            item.clearFlags = CameraClearFlags.Skybox;

        }

    }
    void Start()
    {

        if (skyChange == true)
        {
            ChangeSky();

        }
        else
        {
            ChangeSkybox();
        }
    }

}



