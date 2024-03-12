using UnityEngine;
using UnityEngine.UI;

public class ColFade : MonoBehaviour
{

    [SerializeField] public float fadeColor;

       public void Changecol()
        {
            var cl = fadeColor;
            GameObject.Find("Fade").GetComponent<Renderer>().material.color = new Color (0,0,0,fadeColor);
        }

    private void Update()
    {
        Changecol();
    }

}
