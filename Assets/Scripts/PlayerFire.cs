using System;
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
    public int initBulletCnt = 6;
    // 총알 탄창
    public List<GameObject> magazine = new List<GameObject>();

    void Start()
    {        
        // 총알 6개 만들자
        for(int i = 0; i < initBulletCnt; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            // 만들어진 총알을 비활성화 하자.
            bullet.SetActive(false);

            // 총알을 탄창에 넣자
            magazine.Add(bullet);            
        }
    }

    void Update()
    {
        // 1. 마우스 왼쪽버튼을 누르면 
        // bool isClick = Input.GetButtonDown("Fire1");
        if(Input.GetButtonDown("Fire1"))
        //if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            // 탄창에서 총알을 가져오자.
            GameObject bullet = magazine[0];
            // 가져온 총알을 총구에 놓자
            bullet.transform.position = firePos.transform.position;
            // 가져온 총알을 활성화 하자.
            bullet.SetActive(true);
            // 탄청에서 가져온 총알을 빼자.
            magazine.RemoveAt(0);

            #region 하나하나 총알을 생성하는 방법
            //// 2. 총알공장(Prefab) 에서 총알을 생성하자.
            //GameObject bullet = Instantiate(bulletFactory);

            //// 3. 생성된 총알의 위치를 총구 위치에 놓자.
            //bullet.transform.position = firePos.transform.position;
            ////bullet.transform.position = transform.position + new Vector3(0, 1, 0);

            //GameObject bullet2 = Instantiate(bulletFactory);

            //bullet2.transform.position = firePos2.transform.position;
            #endregion

        }
    }
}
