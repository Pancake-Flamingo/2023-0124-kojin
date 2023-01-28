using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed;

    //private bool isMoving = false;
    //private bool isDieing = false;
    private Vector2 pos;
    public int num = 1;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 scale = gameObject.transform.localScale;
        transform.Translate(transform.right * Time.deltaTime * 1 * num);

        if( num == 1)
        {
            scale.x *= 1;
        }
        else
        {
            scale.x *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwing")
        {
            Debug.Log("Enemy_Die");
            Destroy(gameObject, 0.2f);
        }
    }
}
