using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 속력
    public float moveSpeed = 7;

    void Start()
    {
        
    }

    void Update()
    {
        // 위로 계속 올라가고 싶다. (P = P0 + vt)
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
       

}
