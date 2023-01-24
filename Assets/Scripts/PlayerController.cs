﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject Object;

    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;
    public bool isObjectHit { set; get; } = false;
    public GameObject HitObject;

    float timer;


    // メインループ
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isMoving = horizontal != 0;
        isFalling = rb.velocity.y < -0.5f;

        Vector3 scale = gameObject.transform.localScale;
        if (isMoving)
        {
            if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling)
        {
            Jump();
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && isObjectHit)
        {
            Object = HitObject;
            isObjectHit = false;
            Object.GetComponent<Rigidbody2D>().freezeRotation = true; 
        }
        else if (Input.GetKeyDown(KeyCode.W) && Object != null)
        {
            Object.GetComponent<Rigidbody2D>().freezeRotation = false;
            if (scale.x >= 0)
            {
                Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 200));
                Object.tag = "Throwing";
            }
            else
            {
                Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 200));
                Object.tag = "Throwing";
            }

            Object = null;
        }
        if (Object != null)
        {
            Object.gameObject.transform.position = transform.position + new Vector3(0, 0.8f, 0);
        }

        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    void Jump()
    {
        isJumping = true;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage") || collision.CompareTag("Object"))
        {
            isJumping = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Trap")
        {
            Debug.Log("Die_Player");
        }
    }
}