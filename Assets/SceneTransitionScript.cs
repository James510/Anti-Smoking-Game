using UnityEngine;
using System.Collections;

public class SceneTransitionScript : MonoBehaviour
{
    public bool fade=false;
    private bool startFade = true;
    private float transparency;
	// Use this for initialization
	void Start ()
    {
        transparency = 1;
        
    }
	
	void Update ()
    {
        GetComponent<Renderer>().material.color = new Color(0, 0, 0, transparency);
        if (transparency > 1)
            transparency = 1;
        if (transparency < 0)
            transparency = 0;
        if (fade)
        {
            transparency += 0.2f;
            if (startFade)
            {
                StartCoroutine(WaitFade(2.0f));
                startFade = false;
            }
            //Debug.Log("Fading In");
        }
        else
        {
            transparency -= 0.2f;
            //Debug.Log("Fading Out");
        }
    }

    void FadeIn(bool x)
    {
        fade = x;
        startFade = true;
    }
    IEnumerator WaitFade(float f)
    {
        yield return new WaitForSeconds(f);
        //Debug.Log("End Wait");
        fade = false;
    }
}
