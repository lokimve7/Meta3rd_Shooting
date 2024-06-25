using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 속력
    public float enemySpeed = 4;

    // 이동 방향
    Vector3 dir;

    // 플레이어
    public GameObject player;

    void Start()
    {


        // 랜덤한 값을 뽑자 (0 ~ 9)
        int rand = Random.Range(0, 10);
        // 만약에 랜덤한 값이 4 보다 작으면 (40% 확률)
        if(rand < 4)
        {
            // 방향을 아래로 하자.
            dir = Vector3.down;
        }
        // 그렇지 않으면 (나머지 60% 확률)
        else
        {
            // 플레이어를 찾자
            player = GameObject.Find("Player");
            
            // 플레이어를 향하는 방향을 구하자.
            // 1. 플레이어를 향하는 방향을 구하자. (P - E)
            dir = player.transform.position - transform.position;
            // 구한 방향의 크기를 1로 하자 (정규화, Normalize)
            dir.Normalize();
        }             
    }

    void Update()
    {
        // 2. 그 방향으로 움직이고 싶다.
        transform.position += dir * enemySpeed * Time.deltaTime;
        
        //아래로 계속 움직이고 싶다. 
        // P = P0 + vt(v 아래)
        //transform.position += Vector3.down * enemySpeed * Time.deltaTime;

    }
}
