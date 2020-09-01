using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStartSceneAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsAlert", true);
    }


}
