using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    // Enemy 공장
    public GameObject enemyFactory;

    // 생성시간(기준시간)
    public float createTime = 0;
    // 현재시간(누적시간)
    public float currTime = 0;
   
    void Start()
    {
        // 생성시간을 랜덤한 값으로 설정 (0.5 ~ 1.5)
        createTime = Random.Range(0.5f, 1.5f);
    }

    void Update()
    {        
        // 현재 게임중이 아니라면 함수를 나가자.
        if (GameManager.instance.isPlaying == false) return;

        // 시간을 흐르게 하자(DeltaTime 누적)
        currTime += Time.deltaTime;

        // 만약에 1초가 지났다면 (현재시간 > 생성시간 )
        if (currTime > createTime)
        {           
            // Enemy 를 하나 생성하자.
            GameObject enemy = Instantiate(enemyFactory);
            // 생성된 Enemy를 나의 위치에 놓자.
            enemy.transform.position = transform.position;
            // 현재시간을 초기화
            currTime = 0;
            // 생성시간을 랜덤한 값으로 설정 (0.5 ~ 1.5)
            createTime = Random.Range(0.5f, 1.5f);
        }
    }
}
