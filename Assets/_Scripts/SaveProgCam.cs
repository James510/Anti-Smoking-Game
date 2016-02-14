
using UnityEngine;
using UnityEngine.UI;

public class SaveProgCam : MonoBehaviour
{
    public bool isPaused;
    public Button Save1, Exit, Resume;
    public Text stress, money, health;
    // Use this for initialization
    void Start()
    {

        stress.text = "Stress: " + PlayerPrefs.GetInt("Stress");
        money.text = ": " + PlayerPrefs.GetInt("Money");
        health.text = ": " + PlayerPrefs.GetInt("Health");
        Save1.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        Resume.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0.0f;
            isPaused = true;
            Save1.gameObject.SetActive(true);
            Exit.gameObject.SetActive(true);
            Resume.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && isPaused)
        {
            print("Unpaused");
            Time.timeScale = 1.0f;
            isPaused = false;
            Save1.gameObject.SetActive(false);
            Exit.gameObject.SetActive(false);
            Resume.gameObject.SetActive(false);

        }
    }
    void SaveProg(int stress, int money, int health, int level)
    {
        PlayerPrefs.SetInt("Stress", stress);
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("Level", level);
    }
    void Unpause()
    {
        print("Unpaused");
        Time.timeScale = 1.0f;
        isPaused = false;
        Save1.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        Resume.gameObject.SetActive(false);
    }

    void MainMenu()
    {
        Application.LoadLevel(2);
    }
}

