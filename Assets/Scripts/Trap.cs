using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{    
    private Vector2 pos;

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, 0f, 1f) * Time.deltaTime);
    }
}
