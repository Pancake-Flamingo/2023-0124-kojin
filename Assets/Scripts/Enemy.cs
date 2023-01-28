using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed;
    [SerializeField] public bool isLeft = false;    // true : 左向き


    //private bool isMoving = false;
    //private bool isDieing = false;
    //private Vector2 pos;
	//public int num = 1;
    GroundTouch gt;


	void Start()
	{
        // 地面チェックオブジェクト
        gt = gameObject.transform.GetChild(0).GetComponent<GroundTouch>();

        Vector3 scale = gameObject.transform.localScale;
		if(isLeft)
        {   // 左向きにする
            scale.x *= -1;
            gameObject.transform.localScale = scale;
		}
	}

	void Update()
    {
        Vector3 scale = gameObject.transform.localScale;

        // 地面チェックオブジェクトの状態を見る
        if(!gt.isGround)
        {// 地面がないので反転する
            scale.x *= -1;
            gameObject.transform.localScale = scale;
    	}

        // 左右に移動
        transform.Translate(transform.right * Time.deltaTime * scale.x * moveSpeed);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // オブジェクトでも反転
        if (collision.gameObject.tag == "Object")
        {
            Vector3 scale = gameObject.transform.localScale;
            scale.x *= -1;
            gameObject.transform.localScale = scale;
		}

        if (collision.gameObject.tag == "Throwing")
        {
            Debug.Log("Enemy_Die");
            Destroy(gameObject, 0.2f);
        }
    }
}
