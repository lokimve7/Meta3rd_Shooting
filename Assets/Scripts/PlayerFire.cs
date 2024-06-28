﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFire : MonoBehaviour
{
    // 총알공장(Prefab)
    public GameObject bulletFactory;
    // 총구
    public GameObject firePos;
    public GameObject firePos2;

    // 초기 총알 갯수
    public int initBulletCnt = 5;
    // 총알 탄창
    public List<GameObject> magazine = new List<GameObject>();

    

    void Start()
    {
        #region List 사용법
        // 리스트 변수 생성
        List<string> listStr = new List<string>();

        // 추가
        listStr.Add("one"); //0
        listStr.Add("two"); //1

        print(listStr[1]);

        // 삽입
        listStr.Insert(1, "1.5");   // one, 1.5, two

        // 삭제
        listStr.Remove("one");      // 1.5, two
        listStr.RemoveAt(1);        // 1.5
        #endregion

        // 총알 6개 만들자
        for (int i = 0; i < initBulletCnt; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            // 만들어진 총알을 비활성화 하자.
            bullet.SetActive(false);

            // 총알을 탄창에 넣자
            magazine.Add(bullet);            
        }
    }

    // 현재시간
    float currTime;

    void Update()
    {
        //// 1. 마우스 왼쪽버튼을 누르면 
        //// bool isClick = Input.GetButtonDown("Fire1");
        //if(Input.GetButtonDown("Fire1"))
        ////if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftControl))
        
        // 0.5초 마다 한번씩 총알 발사하고 싶다.
        // 현재시간을 누적하자.
        currTime += Time.deltaTime;
        // 만약에 현재시간이 0.2보다 커지면
        if (currTime > 0.2f)
        {
            // 현재시간을 초기화
            currTime = 0;

            GameObject bullet;

            // 만약에 탄창에 총알이 있다면
            if (magazine.Count > 0)
            {
                // 탄창에서 총알을 가져오자.
                bullet = magazine[0];
                // 가져온 총알을 총구에 놓자
                bullet.transform.position = firePos.transform.position;
                // 가져온 총알을 활성화 하자.
                bullet.SetActive(true);
                // 탄청에서 가져온 총알을 빼자.
                magazine.RemoveAt(0);                
            }            
            // 그렇지 않으면 (탄창에 총알이 없다면)
            else
            {
                #region 하나하나 총알을 생성하는 방법
                // 2. 총알공장(Prefab) 에서 총알을 생성하자.
                bullet = Instantiate(bulletFactory);

                // 3. 생성된 총알의 위치를 총구 위치에 놓자.
                bullet.transform.position = firePos.transform.position;
                //bullet.transform.position = transform.position + new Vector3(0, 1, 0);               
                #endregion
            }

            // Bullet 컴포넌트를 가져오자.
            Bullet bulletComp = bullet.GetComponent<Bullet>();
            // 가져온 컴포넌트로 PlaySound 함수 실행
            bulletComp.PlaySound();
        }
    }
}
