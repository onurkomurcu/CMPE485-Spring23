using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public variables
    public float speed = 20f;
    public float jumpForce = 500f;

    // Private variables
    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded = false;
    public GameObject restartButton;
    public GameObject loseText;
    public GameObject winText;
    private bool hasItem = false;
    private bool trapKilled = false;
    private bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        // Move the player
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);


        // Rotate the player towards movement direction
        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        // Jump the player
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f));
            
            anim.SetBool("isJumping", true);
            isGrounded = false;
        }

        // Set animator parameters
        if (movement.magnitude > 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    // Check if the player is on the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }

        if (collision.gameObject.name == "Cube (38)" || collision.gameObject.name == "Cube (39)" || collision.gameObject.name == "Cube (40)" || collision.gameObject.name == "Cube (41)" || collision.gameObject.name == "Cube (42)" || collision.gameObject.name == "Cube (43)")
        {
            // Finish game
            trapKilled = true;
            Finish();
        }

        if (collision.gameObject.name == "Key")
        {
            // Destroy key
            Destroy(collision.gameObject);
            hasItem = true;
        }

        if ((collision.gameObject.name == "Correct Door (1)" || collision.gameObject.name == "Correct Door (2)") && hasItem)
        {
            // Destroy door
            Destroy(collision.gameObject);
            win = true;
            Finish();
        }

    }

    void Finish()
    {
        // Pause the game and display the message on the screen
        Time.timeScale = 0f;
        
        //Display restart button
        restartButton.SetActive(true);
        if (trapKilled)
        {
            loseText.SetActive(true);
        }
        if (win){
            winText.SetActive(true);
        }
    }
}