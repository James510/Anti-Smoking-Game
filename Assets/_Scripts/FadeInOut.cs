using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    public float inDelay;
    private float outDelay, loadNext;
    public int levelLoad;
    public bool splashScreens;
    public GameObject canvas;
    private bool fadeIn;
    private bool start;
    private bool trigger;
    private bool fadedIn;

	void Start ()
    {
        trigger = true;
        fadeIn = true;
        start = false;
        outDelay = 0;
        loadNext = 1;   
        //Debug.Log("Start Wait");
        StartCoroutine(WaitFadeIn(inDelay));
        if (splashScreens)
        {
            outDelay += inDelay+2;
            loadNext += outDelay+1;
        }
        else
        {
            outDelay = 0;
            loadNext = 2;
            StartCoroutine(WaitFadeInCanvas(inDelay+1));
            canvas.SetActive(false);
        }
    }

    void FadeOut()
    {
        canvas.SetActive(false);
        fadeIn = false;
        //Debug.Log("Fading False");
        //Debug.Log(fadeIn);
        StartCoroutine(WaitLoadNext(loadNext, levelLoad));
    }

	void Update ()
    {
        //Debug.Log(fadeIn);  
        if (fadeIn && start)
        {
            GetComponent<Renderer>().material.color -= new Color(0, 0, 0, .05f);
            //Debug.Log("Fading In");
        }
        else
        {
            GetComponent<Renderer>().material.color += new Color(0, 0, 0, .05f);
            //Debug.Log("Fading Out");
        }
        if(splashScreens && fadedIn && trigger)
        {
            trigger = false;
            StartCoroutine(WaitFadeOut(outDelay));
            StartCoroutine(WaitLoadNext(loadNext, levelLoad));
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(levelLoad);
        }
    }

    IEnumerator WaitFadeIn(float f)
    {
        yield return new WaitForSeconds(f);
        //Debug.Log("End Wait");
        start = true;
        fadedIn = true;
    }
    IEnumerator WaitFadeInCanvas(float f)
    {
        yield return new WaitForSeconds(f);
        //Debug.Log("End Wait");
        canvas.SetActive(true);
    }
    IEnumerator WaitFadeOut(float f)
    {
        yield return new WaitForSeconds(f);
        //Debug.Log("End Wait");
        fadeIn = false;
    }
    IEnumerator WaitLoadNext(float f,int nl)
    {
        yield return new WaitForSeconds(f);
        //Debug.Log("End Wait");
        Application.LoadLevel(nl);
    }
}
