using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject EnenytoSpawn;
    public AudioSource enemyspawnaudio;
    
    void OnTriggerEnter()
    {
        EnenytoSpawn.SetActive(true);
        enemyspawnaudio.Play();
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
