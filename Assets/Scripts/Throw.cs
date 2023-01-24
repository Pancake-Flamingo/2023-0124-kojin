using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Throw : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerController player;
    [SerializeField] float moveSpeed;
    float timer;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            gameObject.transform.tag = "Object";
            timer = 0;
        }
    }
}
