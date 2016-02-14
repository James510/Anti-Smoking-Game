using UnityEngine;
using UnityEngine.UI;
using System.Collections;
    public class MainMenuCamera : MonoBehaviour {
    public Button Play, Load,Options;
    public float hSliderValue = 0.0f;
    public Text Money, Stress, Health;
    void Start()
    {
    }
    void Update()
    {
       // AudioListener.volume = hSliderValue/10.0f;
    }


     void AudioOptions()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(370, 220, 546, 30), hSliderValue, 0.0f, 10.0f);
        AudioListener.volume = hSliderValue / 10.0f;
    }
    void NextScene()
    {
        
        PlayerPrefs.SetInt("Stress",50);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("Health", 100);
        Application.LoadLevel(3);
    }
    
    void LoadScene(int SceneCounter)
    {
        PlayerPrefs.GetInt("Level");
    }
}
