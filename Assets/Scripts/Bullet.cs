using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 속력
    public float moveSpeed = 7;

    void Start()
    {
        
    }

    void Update()
    {
        // 위로 계속 올라가고 싶다. (P = P0 + vt)
        transform.position += transform.up * moveSpeed * Time.deltaTime;
        //transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }
       
    public void PlaySound()
    {
        // AudioSource 컴포넌트 가져오자
        AudioSource audio = GetComponent<AudioSource>();
        // 가져온 컴포넌트에서 Play 함수 실행
        audio.Play();
    }
}
