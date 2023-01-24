using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] PlayerController player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            Debug.Log(collision.gameObject.name);
            player.isObjectHit = true;
            player.HitObject = collision.gameObject;
        }
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject.name);
            player.isObjectHit = false;
        }
    }
}
