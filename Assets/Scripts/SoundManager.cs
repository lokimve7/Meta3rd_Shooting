using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;




public class SoundManager : MonoBehaviour
{
    // enum, 열거형
    public enum ESoundType
    {
        EFT_BULLET,
        EFT_DESTORY,
        EFT_DAMAGE,
    }
    public enum EBgmType
    {
        BGM_TITLE,
        BGM_INGAME,
        BGM_RESULT
    }

   

    // 나를 담을 static 변수
    static SoundManager instance;
    public static SoundManager Get()
    {
        // 만약에 instance 가 null 이라면
        if(instance == null)
        {
            // SoundManager Prefab 을 읽어오자
            GameObject soundManagerFactory = Resources.Load<GameObject>("SoundManager");
            // SoundManager 공장에서 SoundManager를 만들자.
            GameObject soundManager = Instantiate(soundManagerFactory);           
        }

        return instance;
    }
   

    // audiosource
    public AudioSource eftAudio;
    public AudioSource bgmAudio;

    // effect audio clip 을 여러개 담아 놓을 변수
    // 0 : 총알발사
    // 1 : 터지는 소리

    public AudioClip[] eftAudios;
    public AudioClip[] bgmAudios;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            // 씬 전환이 되도 게임오브젝트를 파괴하고 싶지않다.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    // effect Sound Play 하는 함수
    public void PlayEftSound(ESoundType idx)
    {
        int audioIdx = (int)idx;
        eftAudio.PlayOneShot(eftAudios[audioIdx]);
    }

    // bgm Sound Play
    public void PlayBgmSound(EBgmType idx)
    {
        int bgmIdx = (int)idx;
        // 플레이 할 AudioClip 을 설정
        bgmAudio.clip = bgmAudios[bgmIdx];
        // 플레이!
        bgmAudio.Play();
    }

    public void AudioSourceEtc()
    {
        // 일시정지
        bgmAudio.Pause();
        // 완전 멈춤
        bgmAudio.Stop();
        // 현재 실행되고있는 시간
        float currTime = bgmAudio.time;

        bgmAudio.time += 10;
    }
 
}
