using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerAI : MonoBehaviour
{
    public GameObject stalkerDest;
    NavMeshAgent stalkerAgent;
    public GameObject stalkerEnemy;
    public static bool isStalking;
    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isStalking == false)
        {
            stalkerEnemy.GetComponent<Animator>().Play("Breathing Idle");
        }
        
        else
        {
            stalkerEnemy.GetComponent<Animator>().Play("Running");
            stalkerAgent.SetDestination(stalkerDest.transform.position);
        }
        
    }
}
