using UnityEngine;
using System.Collections;

public class DialogueCall : MonoBehaviour
{
    public GameObject cameraController;
    private bool triggerText = false;
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && triggerText == false)
        {
            triggerText = true;
            cameraController.SendMessage("BeginDialogue ");
        }
    }
}
