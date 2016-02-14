using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cigarette : MonoBehaviour
{
    //public float timer=0.1f;
    public Text Stress;
    private int Stress1 = 0;
    void Update()
    {
        //Debug.Log(Time.time);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
        //if (Time.time > timer)
        //gameObject.layer = 0;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //collider.gameObject.SendMessage("ScoreIncrease", 100);
            Stress1 = PlayerPrefs.GetInt("Stress");
            Stress1+=10;
            PlayerPrefs.SetInt("Stress", Stress1);
            Stress.text = "Stress: " + Stress1;
            Destroy(gameObject);
        }
    }
}