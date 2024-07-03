using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    float maxHP = 10;
    float currHP;

    public Image imgHP;

    public Action OnDie;
    
    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHP(float hp)
    {
        currHP += hp;

        float hpRatio = currHP / maxHP;
        imgHP.fillAmount = hpRatio;
        
        if(currHP <= 0)
        {
            if(OnDie != null)
            {
                OnDie();
            }
        }
    }
}
