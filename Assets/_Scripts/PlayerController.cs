using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int hp, score;
    public float speed, jumpForce;
    private Rigidbody rb;
    private bool canJump, mud;
    public GameObject Respawn;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }

    void CanJump()
    {
        canJump = true;
    }

    void Update()
    {
        //respawn for when he moves out of bounds/below -2 y
        if(transform.position.y < -2.0f)
        {
            transform.position = new Vector3(Respawn.transform.position.x,Respawn.transform.position.y,0.0f);
        }
        Debug.Log(mud);
        //Vector3 movement = new Vector3(horizontal * speed, transform.position.y, 0.0f);
        //rb.velocity = movement;
        if (mud == true)
        {
            speed = 10;
            jumpForce = 80;
        }
        else
        {
            jumpForce = 400;
            speed = 50;
        }
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-speed, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(speed, 0.0f, 0.0f);
        //Debug.Log(rb.velocity.y);
        /*if (canJump == false && rb.velocity.y < 0.00000000000000001f)
        {
            canJump = true;
        }*/
        if (canJump && (Input.GetButton("Jump") || Input.GetKey(KeyCode.W)))
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = false;
        }
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -1.0f, 1.0f), Mathf.Clamp(rb.velocity.y, -5.0f, 5.0f), 0.0f);
        rb.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //Debug.Log(canJump);
    }
    /*void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit");
        if(other.tag==("Platform"))
        {
            canJump = true;
        }
    }*/

    void ScoreIncrease(int s)
    {
        score += s;
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Mud"))
        {
            mud = true;
        }
        
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Mud"))
        {
            mud = false;
        }
    }
}