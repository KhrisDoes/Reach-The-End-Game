using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody player;
    private float forwardSpeed = 10f;
    private float sidewaysSpeed = 4f;
    private float jumpSpeed = 5f;
    public static bool isGrounded = true;
    private bool CanDoubleJump = false;
    private ShootBullet sb;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        sb = GetComponent<ShootBullet>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * sidewaysSpeed);
        }

        if (Input.GetKeyDown("space"))
        {
            if (isGrounded)
            {
                Jump();
                // CanDoubleJump = true;
            }
            /*
            else
            {
                if (CanDoubleJump)
                {
                    Jump();
                    sb.FireDownward();
                    CanDoubleJump = false;
                }
            }
            */
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    public void PauseGame()
    {
        ResumeGame.CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Jump()
    {
        player.velocity = Vector3.up * jumpSpeed;
    }

    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        /*
         
        if(collision.gameObject.tag == "Ground" && ShootBullet.NumOfBullets > 0)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }

    */
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground" && !isGrounded)
        {
            isGrounded = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            ShootBullet.AddBullet();
        }
    }
}
