using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    public AudioSource audio;

    private float NextStomp;
    public float stompRate = 1.0f;

    public float velocityDiff = 5.0f;
    public float velocityBoostTime = 1.0f;
 
    private float moveInput;
    float scaleX;

    public float moveSpeed;
    public float acceleration;
    public float decceleration;
    public float maxVelocityY;
    public float jumpForce;
    private bool isJumping;

    public float aerialMultiplier = 0.5f;

    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {


        if (rb.velocity.y > maxVelocityY)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVelocityY);
        }

        if (Input.GetKeyUp("a") | Input.GetKeyUp("d"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        

        #region Run

        float targetSpeed = moveInput * moveSpeed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = speedDif * accelRate;

        if (!isJumping)
        {
            movement *= aerialMultiplier;
        }

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);


        #endregion

        #region Jump

        if (Input.GetKey(KeyCode.Space) && Time.time > NextStomp)
        {
            NextStomp = Time.time + stompRate;
            StartCoroutine(dashWait());
            rb.AddForce(jumpForce * Vector2.down, ForceMode2D.Impulse);
            
        }
        
        IEnumerator dashWait()
        {
            Debug.Log("wait start");
            maxVelocityY += velocityDiff;
            yield return new WaitForSeconds(velocityBoostTime);
            maxVelocityY -= velocityDiff;
        }
        
        #endregion

        Flip();
        
    }

    public void Flip()
    {
        if (moveInput > 0) 
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            print("Grounded");
            animator.SetTrigger("Ground Trigger");
            audio.Play();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
