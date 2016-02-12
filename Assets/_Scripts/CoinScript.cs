using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinScript : MonoBehaviour
{
    //public float timer=0.1f;
    public Text money;
    private int cash=0;
    void Start()
    {
        cash = PlayerPrefs.GetInt("Money");
        money.text = "Money: " + cash;
    }
	void Update ()
    {
        //Debug.Log(Time.time);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
        //if (Time.time > timer)
            //gameObject.layer = 0;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.SendMessage("ScoreIncrease", 100);
            cash++;
            PlayerPrefs.SetInt("Money", cash);
            money.text = "Money: " + cash;
            Destroy(gameObject);
        }
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }*/
}
