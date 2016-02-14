using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour {
    public Text Stress, Money, Health;

    void Start()
    {
        Stress.text = "Stress: " + PlayerPrefs.GetInt("Stress");
        Money.text = "Money: " + PlayerPrefs.GetInt("Money");
        Health.text = "Health: " + PlayerPrefs.GetInt("Health");

    }
	void Update () {
        if (PlayerPrefs.GetInt("Stress") < 0)
            PlayerPrefs.SetInt("Stress", 0);
        if (PlayerPrefs.GetInt("Stress") > 100)
        {
            PlayerPrefs.SetInt("Stress", 0);
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 20);
        }
    }
    void StressBall()//3 6
    {
        if (PlayerPrefs.GetInt("Money") >= 6)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - 6) ;
            PlayerPrefs.SetInt("Stress", PlayerPrefs.GetInt("Stress") - 10);
        }
    }
    void Inhaler()//2 8
    {
        if (PlayerPrefs.GetInt("Money") >= 6)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 6);
            PlayerPrefs.SetInt("Stress", PlayerPrefs.GetInt("Stress") - 15);
        }
    }
    void Cigarette()//4 4
    {
        if (PlayerPrefs.GetInt("Money") >= 4)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 4);
            PlayerPrefs.SetInt("Stress", PlayerPrefs.GetInt("Stress") + 10);
        }
    }
    void Gum()//6 2
    {
        if (PlayerPrefs.GetInt("Money") >= 2)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 2);
            PlayerPrefs.SetInt("Stress", PlayerPrefs.GetInt("Stress") - 2);
        }
    }
    void AntiDepressant()//1  10
    {
        if (PlayerPrefs.GetInt("Money") >= 10)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.SetInt("Stress", PlayerPrefs.GetInt("Stress") - 20);

        }
    }
    void Tea()//5 2
    {
        if (PlayerPrefs.GetInt("Money") >= 2)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 2);
            PlayerPrefs.SetInt("Stress", PlayerPrefs.GetInt("Stress") - 2);
        }
    }

    void Exit()
    {
        Application.LoadLevel(6);
    }
}
