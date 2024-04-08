using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRAdaptBB6 : MonoBehaviour
{

    public Vector2 newSize;
    public GameObject sR;
    void Start()
    {
       sR.GetComponent<SpriteRenderer>().size = newSize;
    }

    //void Update()
    //{

        //SRchange();
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //if (spriteRenderer != null && spriteRenderer.sprite != null)
        //{
            //Vector2 size = new Vector2(desiredWidth, desiredHeight);
           
            //Vector2 newScale;
            //newScale.x = desiredWidth; // spriteRenderer.sprite.bounds.size.x;
            //newScale.y = desiredHeight; // spriteRenderer.sprite.bounds.size.y;
            //transform.localScale = newScale;
        //}
    //}

  
}
