using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    public Sprite door, doorOpen;
    public bool enter = false;
    public int sceneCounter;
    void Activate()
    {
        GetComponent<SpriteRenderer>().sprite = doorOpen;
        enter = true;
    }
    void Deactivate()
    {
        GetComponent<SpriteRenderer>().sprite = door;
        enter = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && enter == true)
        {
            Application.LoadLevel(sceneCounter);
        }
    }
}
