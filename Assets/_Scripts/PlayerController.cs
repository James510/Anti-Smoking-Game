using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public int hp, score;
    public float speed, jumpForce;
    public GameObject spriteController;
    private Rigidbody rb;
    private bool canJump, mud,jumpAnim = false;
    public int playerControllerActive=1;
    private float freezeX, freezeY;
    //private Vector3 saveVelocity;
    public GameObject Respawn;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = spriteController.GetComponent<Animator>();
        canJump = true;
        //saveVelocity = rb.velocity;
    }

    void CanJump()
    {
        canJump = true;
        jumpAnim = true;
    }

    void Update()
    {
        //Debug.Log(playerControllerActive);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerControllerActive *= -1;
            freezeX = transform.position.x;
            freezeY = transform.position.y;
            //rb.velocity = saveVelocity;
            //saveVelocity = rb.velocity;
        }
            
        if (playerControllerActive==1)
        {
            //respawn for when he moves out of bounds/below -2 y
            if (transform.position.y < -2.0f)
            {
                transform.position = new Vector3(Respawn.transform.position.x, Respawn.transform.position.y, 0.0f);
            }
            //Debug.Log(mud);
            //Vector3 movement = new Vector3(horizontal * speed, transform.position.y, 0.0f);
            //rb.velocity = movement;
            if (mud == true)
            {
                speed = 10;
                jumpForce = 100;
            }
            else
            {
                jumpForce = 600;
                speed = 50;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-speed, 0.0f, 0.0f);
                spriteController.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(speed, 0.0f, 0.0f);
                spriteController.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            }
            //Debug.Log(rb.velocity.y);
            /*if (canJump == false && rb.velocity.y < 0.00000000000000001f)
            {
                canJump = true;
            }*/
            if (canJump && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)))
            {
                rb.AddForce(0, jumpForce, 0);
                canJump = false;
            }
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -1.5f, 1.5f), Mathf.Clamp(rb.velocity.y, -6.0f, 6.0f), 0.0f);
            rb.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
            //spriteController.transform.rotation = Quaternion.Euler(0.0f, transform.rotation.y, 0.0f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //Debug.Log(canJump);
            //Animation
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown("space"))// jump animation 
                anim.Play("MainCharGuyJump", -1, 0f);
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && jumpAnim)// if you hold a after jumping
            {
                anim.Play("MainCharGuyRun", -1, 0f);
                jumpAnim = false;
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && jumpAnim) // if you hold  d after jumping
            {
                anim.Play("MainCharGuyRun 1", -1, 0f);
                jumpAnim = false;
            }
            else if (jumpAnim)// when you land and are holding nothing
            {
                anim.Play("MainCharGuy", -1, 0f);
                jumpAnim = false;
            }
            else if (!canJump)// if you cannot jump aka in the air, none of the other animations will run 
            {

            }
            else if (Input.GetKeyDown(KeyCode.D) || (Input.GetKey(KeyCode.D) && Input.GetKeyUp(KeyCode.A))) //right
                anim.Play("MainCharGuyRun", -1, 0f);
            else if (Input.GetKeyDown(KeyCode.A) || (Input.GetKey(KeyCode.A) && Input.GetKeyUp(KeyCode.D))) //left
                anim.Play("MainCharGuyRun 1", -1, 0f);
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                anim.Play("MainCharGuy", -1, 0f);
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
                anim.Play("MainCharGuy", -1, 0f);
            }
        }
        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            transform.position = new Vector3(freezeX, freezeY, -1.0f);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        
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