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

    void Start()
    {
       
    }

    void Update()
    {
        // 1. 마우스 왼쪽버튼을 누르면 
        // bool isClick = Input.GetButtonDown("Fire1");
        if(Input.GetButtonDown("Fire1"))
        //if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            // 2. 총알공장(Prefab) 에서 총알을 생성하자.
            GameObject bullet = Instantiate(bulletFactory);

            // 3. 생성된 총알의 위치를 총구 위치에 놓자.
            bullet.transform.position = firePos.transform.position;
            //bullet.transform.position = transform.position + new Vector3(0, 1, 0);

            GameObject bullet2 = Instantiate(bulletFactory);

            bullet2.transform.position = firePos2.transform.position;
        }
    }
}
