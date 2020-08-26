using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack, stopTime;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerController player;

    public float speed, health, startTimeBtwAttack, startStopTime, normalSpeed; //Скорость бега, очки жизни
    public GameObject deathEffect;
    public int damage;
    private bool trigger = false; //Враг в зоне поражения?


    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        normalSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (trigger)
        {
            speed = 0;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }        

    public void TakeDamage (int damage)
    {
        stopTime = startStopTime;
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        health -= damage;
        
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        
        if (collider.CompareTag("Player"))
        {
            trigger = true;
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsAlert", true);
            anim.SetTrigger("AttackTrigger");
            speed = 0f;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }

    public void OnEnemyAttack()
    {
        //Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}
