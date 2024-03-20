using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static getReal3D.NavigationHelper;

public class SwapTest : MonoBehaviour
{


    /// Type of navigation reference frame
    public enum SceneP
    {
        T1,        //!< Navigation follows the wand
        T2,        //!< Navigtation follows the head
        T3    //!< Navigation follows the navReference field
    };

    public SceneP pT = SceneP.T1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Sch()
    {
        if (pT == SceneP.T1) {SceneManager.LoadScene(0);}
        if (pT == SceneP.T2) { SceneManager.LoadScene(1);}
        if (pT == SceneP.T3) { SceneManager.LoadScene(2);}
    }

}
