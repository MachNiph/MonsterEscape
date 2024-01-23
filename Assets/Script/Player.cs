using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;

    public Rigidbody2D playerBody;

    public Animator anim;
    public string walk_anim = "walk";
    public string jump_anim = "jump";

    public bool isjumping = false;
    public bool isGrounded;

    public static bool isAlive=true;

    private string ground_tag = "Ground";
    private string enemy_tag = "Enemy";
    
    public SpriteRenderer spritePlayer;

    public float movementX;

    void Update()
    {
        playerMovement();
        AnimatePlayer();
        JumpPlayer();
    }

    void playerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveSpeed * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(walk_anim, true);
            spritePlayer.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(walk_anim, true);
            spritePlayer.flipX = true;
        }
        else
        {
            anim.SetBool(walk_anim, false);
        }

        anim.SetBool(jump_anim, !isGrounded);
    }

    void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        if (collision.gameObject.CompareTag(ground_tag) )
        {
            isGrounded = true;
        }



        if (collision.gameObject.CompareTag(enemy_tag) )

        {
            Debug.Log("hit");
            HandlePlayerDeath();
            isAlive = false;
            
        }
    }

   

    public void HandlePlayerDeath()
    {
       
        UIController uiController = FindAnyObjectByType<UIController>();

        if (uiController != null)
        {
            uiController.EnableButtons();
            Destroy(gameObject);
          

        }
    }
}


