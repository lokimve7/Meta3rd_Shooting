using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    // 스크롤 속력
    public float scrollSpeed = 0.2f;

    Material mat;

    void Start()
    {
        // MeshRenderer 가져오기
        MeshRenderer mr = GetComponent<MeshRenderer>();
        // mr 에 있는 Material 가져오기
        mat = mr.material;
    }

    void Update()
    {
        // 아래로 움직이고 싶다.
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        // 만약에 위치의 y 값이 -25 보다 작으면
        if(transform.position.y < -25)
        {
            // 나의 위치를 위로 75만큼 올려준다.
            transform.position += Vector3.up * 75;

            //transform.position = new Vector3(
            //    transform.position.x, 
            //    transform.position.y + 75,
            //    transform.position.z);
        }

        // 배경을 스크롤하고 싶다. (material -> offset 의 y 값을 변경)
        //mat.mainTextureOffset += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}
