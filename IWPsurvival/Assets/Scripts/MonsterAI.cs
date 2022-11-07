using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    private NavMeshAgent enemynav;
    public Transform playertarget;
    public float enemySpeed = 0.001f;
    public bool attackTrigger;
    public bool isAttacking;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public int hurtGen;


    void Start()
    {
        enemynav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(thePlayer.transform);
        if(attackTrigger == false)
        {
            enemySpeed = 0.01f;
            theEnemy.GetComponent<Animation>().Play("arach_armature_walk");
            //transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
            enemynav.SetDestination(playertarget.position);
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
        if (hurtGen == 1)
        {
            hurtSound1.Play();
        }
        if (hurtGen == 2)
        {
            hurtSound2.Play();
        }
        if (hurtGen == 3)
        {
            hurtSound3.Play();
        }
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;
        hurtGen = Random.Range(1, 4);
        
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}
