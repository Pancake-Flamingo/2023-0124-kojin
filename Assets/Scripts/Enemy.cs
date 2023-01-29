using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed;
    [SerializeField] public bool isLeft = false;    // true : 左向き

    BoxCollider2D col;
    Rigidbody2D rb;
    GroundTouch gt;

    bool isDead = false;                            // 死亡フラグ



	void Start()
	{
        col = GetComponent<BoxCollider2D>();
        rb  = GetComponent<Rigidbody2D>();

        isDead = false;

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
        if(isDead){ return;}                        // 死亡時にプルプルしないように以降の処理はしない

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
            isDead = true;                      // 死亡フラグ

            Debug.Log("Enemy_Die");
            animator.Play("Enemy Die Animation");
            col.enabled = false;
            rb.AddForce(new Vector2(50, 200));
            Destroy(gameObject, 1f);
        }
    }
}
