using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class StalkerAttackingAI : MonoBehaviour
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
        public AudioSource stab;
        public int hurtGen;
        public GameObject hurtflash;
        public GameObject BlackScreen;
    public bool isExit;



    void Start()
    {
        enemynav = GetComponent<NavMeshAgent>();
        isExit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        

            transform.LookAt(thePlayer.transform);
            if (attackTrigger == false)
            {
                enemySpeed = 0.01f;
                theEnemy.GetComponent<Animation>().Play("Running");
            
                enemynav.SetDestination(playertarget.position);
                Debug.Log("mutant is not attacking");
            }
            else if (attackTrigger == true && isAttacking == false&&isExit==false)
            {
                enemySpeed = 0;
           
                theEnemy.GetComponent<Animation>().Play("Mutant Swiping");
                StartCoroutine(InflictDamage());
                Debug.Log("mutant is attacking");
            }

            if (GlobalHealth.currentHealth <= 0)
            {
                BlackScreen.SetActive(true);
                SceneManager.LoadScene(1);
               
            }

            

    }

        void OnTriggerEnter()
        {
            attackTrigger = true;
            isAttacking = false;
            Debug.Log("eneterd player");
            isExit = false;
        }

        void OnTriggerExit()
        {
            isExit = true;
        
            StartCoroutine(waitforanim());
        }

        IEnumerator waitforanim()
        {
            yield return new WaitForSeconds(1.5f);
            attackTrigger = false;
            yield return new WaitForSeconds(0.5f);
            isExit = false;
            isAttacking = true;

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


        yield return new WaitForSeconds(1.4f);
        if (isExit == false)
        {

            GlobalHealth.currentHealth -= 20;

            hurtflash.SetActive(true);
            stab.Play();
            yield return new WaitForSeconds(1.6f);
            hurtflash.SetActive(false);

            yield return new WaitForSeconds(1.1f);
            hurtGen = Random.Range(1, 4);

            yield return new WaitForSeconds(0.2f);
            isAttacking = false;


            
        }
        else 
        {
            isExit = true;
            yield return new WaitForSeconds(0.5f);
            isExit = false;
            isAttacking = true;
        }

        
    }
}

