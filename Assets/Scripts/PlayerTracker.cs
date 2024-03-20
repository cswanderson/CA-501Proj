using System;
using System.Collections.Generic;
using getReal3D;
using TMPro;
using UnityEngine;

public class PlayerTracker : SingletonMonoBehavior<PlayerTracker>
{
    [SerializeField] private List<TextMeshProUGUI> fields;
    
    private void Update()
    {
        foreach (TextMeshProUGUI tmp in fields)
        {
            tmp.text = Plugin.getClusterID().ToString();
        }
    }
}
