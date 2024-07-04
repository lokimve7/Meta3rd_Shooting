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
        Vector3 pos = transform.position;
        pos += dir * 5 * Time.deltaTime;

        Vector3 playerPos = pos;
        playerPos.x -= 0.5f;
        playerPos.y -= 0.5f;
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(playerPos);

        playerPos = pos;
        playerPos.x += 0.5f;
        playerPos.y += 0.5f;
        Vector3 viewportPoint2 = Camera.main.WorldToViewportPoint(playerPos);

        Vector3 normal = Vector3.zero;
        // 왼쪽
        if(viewportPoint.x < 0)
        {
            normal = Vector3.right;
        }
        else if(viewportPoint2.x > 1)
        {
            normal = Vector3.left;
        }
        if(viewportPoint2.y > 1)
        {
            normal = Vector3.down;
        }
        else if(viewportPoint.y < 0)
        {
            normal = Vector3.up;
        }

        if(normal.sqrMagnitude > 0)
        {
            float dot = Vector3.Dot(dir, normal);
            dir = dir - 2 * dot * normal;
        }
        else
        {
            
            transform.position = pos;
        }



        if (viewportPoint.x < 0 || viewportPoint.y < 0 ||
            viewportPoint2.x > 1 || viewportPoint2.y > 1)
        {
            
        }
    }
}
