using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Vector3 dir;
    void Start()
    {
        float rand = Random.Range(0.0f, 360.0f);
        dir.x = Mathf.Cos(rand * Mathf.Deg2Rad);
        dir.y = Mathf.Sin(rand * Mathf.Deg2Rad);
        dir.Normalize();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 pos = transform.position;
        pos += dir * 5 * Time.deltaTime;

        Vector3 leftBottom = pos + new Vector3(-0.5f, -0.5f);
        leftBottom = Camera.main.WorldToViewportPoint(leftBottom);
        Vector3 rightTop = pos + new Vector3(0.5f, 0.5f);
        rightTop = Camera.main.WorldToViewportPoint(rightTop);


        Vector3 normal = Vector3.zero;
        // 왼쪽
        if (leftBottom.x < 0)
        {
            normal = Vector3.right;
        }
        // 아래
        if (leftBottom.y < 0)
        {
            normal = Vector3.up;
        }
        // 오른쪽
        if (rightTop.x > 1)
        {
            normal = Vector3.left;
        }
        // 위
        if (rightTop.y > 1)
        {
            normal = Vector3.down;
        }

        if (normal.sqrMagnitude > 0)
        {
            float dot = Vector3.Dot(dir, normal);
            dir = dir - 2 * dot * normal;
        }
        else
        {
            transform.position = pos;
        }
    }
}
