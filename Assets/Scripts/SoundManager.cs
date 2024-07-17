using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enum, 열거형


public class SoundManager : MonoBehaviour
{
    // 나를 담을 static 변수
    public static SoundManager instance;

    // audiosource
    AudioSource audio;

    // effect audio clip 을 여러개 담아 놓을 변수
    public AudioClip[] eftAudios;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // audiosource 가져오자
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    // effect Sound Play 하는 함수
    public void PlayEftSound(int idx)
    {
        audio.PlayOneShot(eftAudios[idx]);
    }

}
