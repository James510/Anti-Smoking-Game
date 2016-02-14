using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public Text stress, health, money;
    public Button option1, option2;
    public int stressCount, healthCount, moneyCount;
	void Start ()
    {
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);

        stress.text = "Stress: " + PlayerPrefs.GetInt("Stress");
        money.text = ": " + PlayerPrefs.GetInt("Money");
        health.text = ": " + PlayerPrefs.GetInt("Health");

    }
	
	// Update is called once per frame
	void Update ()
    {


        if (PlayerPrefs.GetInt("Stress") < 0)
            PlayerPrefs.SetInt("Stress", 0);
        if (PlayerPrefs.GetInt("Stress") > 100)
        {
            PlayerPrefs.SetInt("Stress", 0);
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 20);
        }
    }

    void StressInc(int n)
    {
        stressCount += n;
    }
    void HealthInc(int n)
    {
        healthCount += n;
    }
    void Decision(string[] choices)
    {
        option1.gameObject.SetActive(true);
        option2.gameObject.SetActive(true);
        option1.GetComponentInChildren<Text>().text = choices[0];
        option2.GetComponentInChildren<Text>().text = choices[1];
    }
    void Decided()
    {
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
    }
    void NextScene(int scene)
    {
        Application.LoadLevel(scene);
    }
}
