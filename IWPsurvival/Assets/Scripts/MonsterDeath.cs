using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeath : MonoBehaviour
{
    public static int EnemyHealth = 20;
    public GameObject Enemy;
    public int StatusCheck;
    //public AudioSource JumpMusic;
    void DamageMonster(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }


    void Update()
    {
        if(EnemyHealth<= 0 && StatusCheck == 0)
        {
            this.GetComponent<MonsterAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            Enemy.GetComponent<Animation>().Stop("arach_armature_walk");
            Enemy.GetComponent<Animation>().Play("arach_armature_death2");
            Debug.Log("arach is dead");
            //JumpMusic.Stop();
        }
    }
}
