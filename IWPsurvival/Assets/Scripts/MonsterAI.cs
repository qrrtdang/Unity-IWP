using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed = 0.001f;
    public bool attackTrigger;
    public bool isAttacking;

    

    

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(thePlayer.transform);
        if(attackTrigger == false)
        {
            enemySpeed = 0.01f;
            theEnemy.GetComponent<Animation>().Play("arach_armature_walk");
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
            Debug.Log("arach is not attacking");
        }
        else if(attackTrigger == true && isAttacking == false)
        {
            enemySpeed = 0;
            //theEnemy.GetComponent<Animation>().Stop("arach_armature_walk");
            theEnemy.GetComponent<Animation>().Play("arach_armature_attack1");
            StartCoroutine(InflictDamage());
            Debug.Log("arach is attacking");
        }
        


    }

    void OnTriggerEnter()
    {
        attackTrigger = true;
        Debug.Log("eneterd player");
    }

    void OnTriggerExit()
    {
        StartCoroutine(waitforanim());
    }

    IEnumerator waitforanim()
    {
        yield return new WaitForSeconds(1.0f);
        attackTrigger = false;
    }


    IEnumerator InflictDamage()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}