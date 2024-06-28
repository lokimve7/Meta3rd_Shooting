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

    // 폭발효과공장(Prefab)
    public GameObject exploFactory;

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

            // 만약에 player 를 잘 찾았다면
            if(player != null)
            {
                // 플레이어를 향하는 방향을 구하자.
                // 1. 플레이어를 향하는 방향을 구하자. (P - E)
                dir = player.transform.position - transform.position;
                // 구한 방향의 크기를 1로 하자 (정규화, Normalize)
                dir.Normalize();
            }
            // player 를 못찾았다면
            //else
            //{
            //    dir = Vector3.down;
            //}
        }
        Destroy(gameObject, 10);
    }

    void Update()
    {
        // 2. 그 방향으로 움직이고 싶다.
        transform.position += dir * enemySpeed * Time.deltaTime;
        
        //아래로 계속 움직이고 싶다. 
        // P = P0 + vt(v 아래)
        //transform.position += Vector3.down * enemySpeed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        // 만약에 부딪힌 오브젝트이 총알이라면
        if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            // 부딪힌 총알 비활성화
            other.gameObject.SetActive(false);
            //총알이면 탄창에 넣자.
            GameObject player = GameObject.Find("Player");
            PlayerFire playerFire = player.GetComponent<PlayerFire>();
            playerFire.magazine.Add(other.gameObject);

            // 폭발효과를 생성하자.
            GameObject explo = Instantiate(exploFactory);
            // 생성된 폭발효과를 나의 위치에 놓자.
            explo.transform.position = transform.position;
            // 생성된 폭발효과에서 ParticleSystem 컴포넌트 가져오자.
            ParticleSystem ps = explo.GetComponent<ParticleSystem>();
            // 가져온 컴포넌트를 Play 하자.
            ps.Play();
        }
        // 그렇지 않고 만약에 부딪힌 오브젝트의 이름이 DestroyZone 을 포함하고 있지 않다면
        else if (other.gameObject.name.Contains("Destroy") == false)
        {
            // 부딪힌 오브젝트 없애자
        
            Destroy(other.gameObject);
        }
        
       
        // 나를 없애자
        Destroy(gameObject);
    }
}
