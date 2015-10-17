﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    private Animator animator;
    private bool dead;
    private bool touchingEnemy;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (touchingEnemy)
            {
                dead = true;
                animator.Play("dead");
                StartCoroutine(KillOnAnimationEnd());
            }

        }
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    if (Input.GetKey(KeyCode.K))
    //    {
    //        dead = true;
    //        animator.Play("dead");
    //        StartCoroutine(KillOnAnimationEnd());
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchingEnemy = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchingEnemy = false;
        }
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(3.95f);
        this.gameObject.SetActive(false);
    }
}