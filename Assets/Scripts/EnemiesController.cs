using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public float speed, checkRadius, health; //Скорость бега и радиус отслеживания, очки жизни

    private Rigidbody2D rb;
    private Animator anim;
    private float moveImput;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }        

    public void TakeDamage (int damage)
    {
        health -= damage;
    }
}
