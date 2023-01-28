using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTouch : MonoBehaviour
{

    [SerializeField] public bool isGround = false;


    // 地面に当たっているかだけを調べる

    void Start()
    {
        isGround = false;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stage"))
        {
            isGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Stage"))
        {
            isGround = false;
        }
    }
}
