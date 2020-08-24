using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public float speed, checkRadius; //Скорость бега и радиус отслеживания

    private Rigidbody2D rb;
    private Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
    }
}
