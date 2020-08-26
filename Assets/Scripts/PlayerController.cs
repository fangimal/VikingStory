using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpForce, health;
    public Transform feetPos; //Считываем позицию ног, для определения на земле ли персонаж
    public float checkRadius; // Радиус касаная игрока с землёй
    public LayerMask whatIsGround; // Что мы считаем за землю
    public int damage;

    private float moveImput;
    private Rigidbody2D rb;
    private bool facinRight = true;
    private bool isGrounded; //Приземлился ли игрок
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
        }
        if (isGrounded == true) anim.SetBool("IsJumping", false);
        else anim.SetBool("IsJumping", true);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("AttackTrigger");
            //if (colider.CompareTag("Enemies"))
            //{

            //}
        }

    }
    private void FixedUpdate()
    {
        moveImput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveImput * speed, rb.velocity.y);
        if (facinRight == false && moveImput > 0)
        {
            Flip();
        }
        else if (facinRight == true && moveImput < 0)
        {
            Flip();
        }
        if (moveImput == 0) //Если игрок не двигается
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }
    }


    void Flip()
    {
        facinRight = !facinRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
