using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour
{
    public GameObject player;
    // Use this for initialization

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Platform"))
        {
            player.SendMessage("CanJump");
        }
    }
}
