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
        // 배경을 스크롤하고 싶다. (material -> offset 의 y 값을 변경)
        mat.mainTextureOffset += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}
