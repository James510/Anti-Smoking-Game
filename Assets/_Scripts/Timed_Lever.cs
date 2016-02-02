using UnityEngine;
using System.Collections;

public class Timed_Lever : MonoBehaviour
{
    public GameObject activator;
    public Sprite pulled;
    public Sprite Lever;
    private bool pulledLever;
    public float  eventTime;
    private float closeDoorTimer;
    // Use this for initialization
    void Start()
    {
        pulledLever = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !pulledLever)
        {
            activator.SendMessage("Activate");
            pulledLever = true;
            closeDoorTimer = Time.time + eventTime;
            GetComponent<SpriteRenderer>().sprite = pulled;
        }

    }
    void Update()
    {
        if (Time.time > closeDoorTimer)
        {
            activator.SendMessage("Deactivate");
            pulledLever = false;
            GetComponent<SpriteRenderer>().sprite = Lever;
        }
    }
}