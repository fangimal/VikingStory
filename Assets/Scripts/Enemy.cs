using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack, stopTime;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerController player;
    private ScoreManager sm;

    public float speed, health, startTimeBtwAttack, startStopTime, normalSpeed; //Скорость бега, очки жизни
    public GameObject deathEffect;
    public int damage;
    private bool trigger = false; //Враг в зоне поражения?


    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float xPos = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (xPos <= 5f)
        {
            speed = 0f;
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsAlert", true);
        }
        else
        {
            speed = normalSpeed;
            anim.SetBool("IsAlert", false);
            anim.SetBool("IsRunning", true);
        }

        if (trigger)
        {
            speed = 0;
        }
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            sm.Kill();
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
            //trigger = true;
            speed = 0f;
            anim.SetBool("IsRunning", false); 
            anim.SetTrigger("AttackTrigger");
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
