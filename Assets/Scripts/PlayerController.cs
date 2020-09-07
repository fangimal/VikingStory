using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public float speed, jumpForce, health;
    public float heal;
    public float normalSpeed;
    public Transform feetPos; //Считываем позицию ног, для определения на земле ли персонаж
    public float checkRadius; // Радиус касаная игрока с землёй
    public LayerMask whatIsGround; // Что мы считаем за землю
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart, emptyHeart;

    private float moveImput;
    private Rigidbody2D rb;
    //private bool facinRight = true;
    private bool isGrounded; //Приземлился ли игрок
    private Animator anim;
    private LevelManager levelManager; 


    void Start()
    {
        speed = 0f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);


        if (isGrounded == true) anim.SetBool("IsJumping", false);
        else anim.SetBool("IsJumping", true);

        //Управление с клавиатуры
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpButtonDown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnLeftButtonDown();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnRightButtonDown();
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) OnButtonUp();


        //if (Input.GetMouseButtonDown(0))
        //{
        //    Instantiate(sound, transform.position, Quaternion.identity);
        //    anim.SetTrigger("AttackTrigger");
        //}

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if(speed != 0f)
        {
            anim.SetBool("IsRunning", true);
        }

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        health += Time.deltaTime * heal;

        for(int i=0; i<hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if (health < 1)
            {
                
                levelManager.LoadLevel("StartMenu");
}
        }

        //moveImput = Input.GetAxis("Horizontal");
        
        //if (facinRight == false && moveImput > 0)
        //{
        //    Flip();
        //}
        //else if (facinRight == true && moveImput < 0)
        //{
        //    Flip();
        //}
        //if (moveImput == 0) //Если игрок не двигается
        //{
        //    anim.SetBool("IsRunning", false);
        //}
        //else
        //{
        //    anim.SetBool("IsRunning", true);
        //}
    }

    public void OnJumpButtonDown()
    {
        if (isGrounded == true) //&& Input.GetKeyDown(KeyCode.Space)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
        }
    }

    public void OnLeftButtonDown()
    {
        if(speed >= 0f)
        {
            speed = -normalSpeed;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void OnRightButtonDown()
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void OnButtonUp()
    {
        speed = 0f;
        anim.SetBool("IsRunning", false);
    }

    //void Flip()
    //{
    //    facinRight = !facinRight;
    //    Vector3 Scaler = transform.localScale;
    //    Scaler.x *= -1;
    //    transform.localScale = Scaler;
    //}
}
