using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{

    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
    }

    void LateUpdate()
    {
        if(playerObj == null){ return; }
        MoveCamera();
    }

    void MoveCamera()
    {
        if(playerObj == null){ return; }

        //Vector3 position = gameObject.transform.localPosition;
        if(playerTransform.position.x < -1.2)
        {
            transform.position = new Vector3(-1.2f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        }
    }

}