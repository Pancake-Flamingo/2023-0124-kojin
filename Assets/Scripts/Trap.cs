using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{    
    private Vector2 pos;

    void Update()
    {
        this.transform.Rotate(0f, 0f, -5f, Space.World);
    }
}
