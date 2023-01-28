using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTouch : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stage"))
        {
            Debug.Log(collision.gameObject.name);
            enemy.num *= 1;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Stage"))
        {
            Debug.Log("exit");
            enemy.num *= -1;
        }
    }
}
