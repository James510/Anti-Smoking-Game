using UnityEngine;
using System.Collections;

public class BGSwitcher : MonoBehaviour
{
    public Sprite[] bgSprite;
    public GameObject FadeController;
    private SpriteRenderer mainSprite;
    private int scene;

	void Start ()
    {
        scene = 0;
        mainSprite = GetComponent<SpriteRenderer>();
    }
	
	void ChangeBackground(int n)
    {
        FadeController.SendMessage("FadeIn", true);
        StartCoroutine("WaitChange", 2.0f);
        
    }
    IEnumerator WaitChange(float f)
    {
        yield return new WaitForSeconds(f);
        //Debug.Log("End Wait");
        mainSprite.sprite = bgSprite[++scene];
    }
}
