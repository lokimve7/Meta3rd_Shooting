using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    // 최대 HP
    public float maxHP = 10;
    // 현재 HP
    float currHP = 0;
    // HP bar UI
    public Image hpBar;

    void Start()
    {
        // 현재 HP 를 최대 HP 로 하자.
        currHP = maxHP;
    }
    void Update()
    {
        // HP bar 를 갱신하자.
        // 0 ~ 1
        //hpBar.fillAmount = currHP / maxHP;
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, currHP / maxHP, 10 * Time.deltaTime);
    }

    // 현재 HP 를 증감하는 함수
    public void UpdateHP(float value)
    {
        // 현재 HP value 더하자.
        currHP += value;
        
        // 현재 HP 가 0이면
        if(currHP <= 0)
        {
            // 파괴되는 효과음
            SoundManager.Get().PlayEftSound(SoundManager.ESoundType.EFT_DESTORY);

            // 파괴하자.
            Destroy(gameObject);
        }
    }
}
