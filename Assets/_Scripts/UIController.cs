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
        stressCount = 75;
        healthCount = 100;
        //moneyCount = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        stress.text = "Stress: " + stressCount;
        health.text = "Health: " + healthCount;
        //money.text = "Money: " + moneyCount;

        if (stressCount < 0)
            stressCount = 0;
        if (stressCount > 100)
            stressCount = 100;
        if (healthCount < 0)
            healthCount = 0;
        if (healthCount > 100)
            healthCount = 100;
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
