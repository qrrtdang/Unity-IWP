using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject EnenytoSpawn;
    
    void OnTriggerEnter()
    {
        EnenytoSpawn.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
