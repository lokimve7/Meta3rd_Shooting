using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 만약에 부딪힌 오브젝트가 총알이면
        if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            // 총알을 비활성화 하고
            other.gameObject.SetActive(false);
            // 총알을 탄창에 넣자.
            // Player 를 찾자.
            GameObject player = GameObject.Find("Player");
            // 찾은 Player 에서 PlayerFire 컴포넌트 가져오자.
            PlayerFire playerFire = player.GetComponent<PlayerFire>();
            // 가져온 컴포넌트의 magazine 변수에 총알을 추가하자.
            playerFire.magazine.Add(other.gameObject);
        }
        // 나머지는
        else
        {
            // 나와 부딪힌 오브젝트를 파괴하자
            Destroy(other.gameObject);
        }
    }
}
