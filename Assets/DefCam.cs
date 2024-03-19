using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GR3D Player").transform.localPosition.Set(newX:19, newY: 60, newZ:-264);
    }
    
}
