using UnityEngine;
using System.Collections;

public class SpriteControllerScript : MonoBehaviour
{
	void Update ()
    {
        transform.rotation = Quaternion.Euler(0.0f, Mathf.Clamp(transform.rotation.y,0.0f,360.0f), 0.0f);
    }
}
