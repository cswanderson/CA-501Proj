using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace getReal3D
{
    public class Move : MonoBehaviour
    {

        public Transform target;
        private Vector3 pos = new Vector3(21, 61, -245);
        private Quaternion rot = new Quaternion(10, 180, 0, 0);
        void Awake()
        {
            if (!target)
            {
                target = transform;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            target.localPosition = pos;
            target.localRotation = rot;
            //GameObject.Find("GR3D Player").GetComponent<Transform>().localPosition.Set(newX: 21, newY: 61, newZ: -254);
    }
    }
}
