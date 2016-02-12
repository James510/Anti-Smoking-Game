using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPanelController : MonoBehaviour {
    public Image panel;
    public RectTransform panelsize;

	void Start () {
        //Scale TextPanel to screen size on level load.
        float width = Screen.width - 200;
        float height = Screen.height / 3;
        panelsize.sizeDelta = new Vector2(width, height);
	}

    void PanelFadeIn() // Fades Panel In
    {
        if (panel.color.a == 255)
        {
            panel.CrossFadeAlpha(80, 3, false);
        }
        else
        {
            Debug.Log("Not Optimized: Panel already faded in. (TextPanelController.cs)");
        }
    }
    void PanelFadeOut() //Fades Panel Out
    {
        if (panel.color.a == 0)
        {
            panel.CrossFadeAlpha(0, .5f, false);
        }
        else
        {
            Debug.Log("Not Optimized: Panel already faded out. (TextPanelController.cs)");
        }
    }
    void RescalePanel() // Rescale Panel Size. Use when game detects a change in window size.
    {
        float width = Screen.width - 200;
        float height = Screen.height / 3;
        panelsize.sizeDelta = new Vector2(width, height);
    }
}
