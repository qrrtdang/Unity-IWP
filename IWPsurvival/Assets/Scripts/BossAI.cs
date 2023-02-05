using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
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
    public int RandomAttack;
    public bool isExit;
    private float timer;



    void Start()
    {
        enemynav = GetComponent<NavMeshAgent>();
        isExit = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        

        transform.LookAt(thePlayer.transform);
        if (attackTrigger == false)
        {
            enemySpeed = 0.01f;
            theEnemy.GetComponent<Animation>().Play("Crouched Walking");
            
            enemynav.SetDestination(playertarget.position);
            Debug.Log("mutant is not attacking");
        }
        else if (attackTrigger == true && isAttacking == false && isExit == false)
        {
            enemySpeed = 0;
            timer = 0;
            
            if (RandomAttack == 1)
            {
                StartCoroutine(InflictDamage());
                theEnemy.GetComponent<Animation>().Play("Mutant Swiping");
            }
            if (RandomAttack == 2)
            {
                StartCoroutine(InflictDamage2());
                theEnemy.GetComponent<Animation>().Play("Uppercut");
            }
            if (RandomAttack == 3)
            {
                StartCoroutine(InflictDamage3());
                theEnemy.GetComponent<Animation>().Play("Mutant Punch");
            }
            
            Debug.Log("mutant is attacking");
            
        }

        if (GlobalHealth.currentHealth <= 0)
        {
            BlackScreen.SetActive(true);
            SceneManager.LoadScene(1);

        }

        if (timer >= 10)
        {
            timer = 0;
        }

        if (timer >= 10 && attackTrigger == false)
        {
            enemySpeed = 0;
            StartCoroutine(waitforbug());
        }


        if (timer < 10)
        {
            enemySpeed = 0.01f;
        }



    }

    IEnumerator waitforbug()
    {
        yield return new WaitForSeconds(0.1f);
        enemySpeed = 0.01f;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RandomAttack = Random.Range(1, 4);
            attackTrigger = true;
            isAttacking = false;
            Debug.Log("eneterd player");
            isExit = false;
            //StartCoroutine(waitforanim());
        }

    }


    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(waitforanim());
            isExit = true;
        }
            
        //attackTrigger = false;
        
    }

    IEnumerator waitforanim()
    {
        if(RandomAttack==1)
        {
            yield return new WaitForSeconds(1.6f);
            attackTrigger = false;
        }
        if (RandomAttack == 2)
        {
            yield return new WaitForSeconds(0.8f);
            attackTrigger = false;
        }
        if (RandomAttack == 3)
        {
            yield return new WaitForSeconds(0.6f);
            attackTrigger = false;
        }

        yield return new WaitForSeconds(0.5f);
        isExit = false;
        isAttacking = true;

    }

    IEnumerator InflictDamage2()
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

        yield return new WaitForSeconds(0.6f);
            if (isExit == false)
            {
                if (RandomAttack == 2)
                {
                    yield return new WaitForSeconds(0.1f);
                    GlobalHealth.currentHealth -= 10;

                    hurtflash.SetActive(true);
                    stab.Play();
                    yield return new WaitForSeconds(1.6f);
                    hurtflash.SetActive(false);

                    yield return new WaitForSeconds(1.1f);
                    hurtGen = Random.Range(1, 4);

                    yield return new WaitForSeconds(0.2f);
                    isAttacking = false;

                }
            }
        
        else
        {
            isExit = true;
            yield return new WaitForSeconds(0.5f);
            isExit = false;
            isAttacking = true;
        }
    }

    IEnumerator InflictDamage3()
    {
        isAttacking = true;
        //if (hurtGen == 1)
        //{
        //    hurtSound1.Play();
        //}
        //if (hurtGen == 2)
        //{
        //    hurtSound2.Play();
        //}
        //if (hurtGen == 3)
        //{
        //    hurtSound3.Play();
        //}

        yield return new WaitForSeconds(0.4f);
            if (isExit == false)
            {
                if (RandomAttack == 3)
                {
                    yield return new WaitForSeconds(0.0f);
                    GlobalHealth.currentHealth -= 8;

                    hurtflash.SetActive(true);
                    stab.Play();
                    yield return new WaitForSeconds(1.6f);
                    hurtflash.SetActive(false);

                    yield return new WaitForSeconds(1.1f);
                    hurtGen = Random.Range(1, 4);

                    yield return new WaitForSeconds(0.2f);
                    isAttacking = false;

                }
            }
        
        else
        {
            isExit = true;
            yield return new WaitForSeconds(0.5f);
            isExit = false;
            isAttacking = true;
        }
    }


    IEnumerator InflictDamage()
    {

        isAttacking = true;
        //if (hurtGen == 1)
        //{
        //    hurtSound1.Play();
        //}
        //if (hurtGen == 2)
        //{
        //    hurtSound2.Play();
        //}
        //if (hurtGen == 3)
        //{
        //    hurtSound3.Play();
        //}

        
            yield return new WaitForSeconds(1.4f);
            if (isExit == false)
            {
                if (RandomAttack == 1)
                {
                    yield return new WaitForSeconds(0.1f);
                    GlobalHealth.currentHealth -= 15;

                    hurtflash.SetActive(true);
                    stab.Play();
                    yield return new WaitForSeconds(1.6f);
                    hurtflash.SetActive(false);

                    yield return new WaitForSeconds(1.1f);
                    hurtGen = Random.Range(1, 4);

                    yield return new WaitForSeconds(0.2f);
                    isAttacking = false;

                }
            }
        
        else
        {
            isExit = true;
            yield return new WaitForSeconds(1.5f);
            isExit = false;
            isAttacking = true;
        }

        

        

        //if (isExit == false)
        //{
        //    if (RandomAttack == 1)
        //    {
        //        yield return new WaitForSeconds(1.4f);
        //        GlobalHealth.currentHealth -= 15;

        //        hurtflash.SetActive(true);
        //        stab.Play();
        //        yield return new WaitForSeconds(1.6f);
        //        hurtflash.SetActive(false);

        //        yield return new WaitForSeconds(1.1f);
        //        hurtGen = Random.Range(1, 4);

        //        yield return new WaitForSeconds(0.2f);
        //        isAttacking = false;

        //    }

        //    if (RandomAttack == 2)
        //    {
        //        yield return new WaitForSeconds(0.6f);
        //        GlobalHealth.currentHealth -= 20;

        //        hurtflash.SetActive(true);
        //        stab.Play();
        //        yield return new WaitForSeconds(1.6f);
        //        hurtflash.SetActive(false);

        //        yield return new WaitForSeconds(1.1f);
        //        hurtGen = Random.Range(1, 4);

        //        yield return new WaitForSeconds(0.2f);
        //        isAttacking = false;

        //    }

        //    if (RandomAttack == 3)
        //    {
        //        yield return new WaitForSeconds(0.4f);
        //        GlobalHealth.currentHealth -= 15;

        //        hurtflash.SetActive(true);
        //        stab.Play();
        //        yield return new WaitForSeconds(1.6f);
        //        hurtflash.SetActive(false);

        //        yield return new WaitForSeconds(1.1f);
        //        hurtGen = Random.Range(1, 4);

        //        yield return new WaitForSeconds(0.2f);
        //        isAttacking = false;

        //    }
        //}




    }
}
