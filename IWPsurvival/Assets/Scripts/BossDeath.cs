using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossDeath : MonoBehaviour
{
    public int EnemyHealth;
    public GameObject Enemy;
    public GameObject BossHPDisplay;
    public int StatusCheck;
    //public AudioSource JumpMusic;
    void DamageMonster(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }


    void Update()
    {
        BossHPDisplay.GetComponent<Text>().text = "" + EnemyHealth;
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<BossAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            Enemy.GetComponent<Animation>().Stop("Crouched Walking");
            Enemy.GetComponent<Animation>().Play("BossDeath");
            Debug.Log("boss is dead");
            //JumpMusic.Stop();
        }
    }
}
