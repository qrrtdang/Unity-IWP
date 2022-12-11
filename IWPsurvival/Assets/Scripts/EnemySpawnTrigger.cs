using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject EnenytoSpawn;
    public AudioSource enemyspawnaudio;
    public GameObject enemytodespawn;
    public bool despawn =false;
    
    void OnTriggerEnter()
    {
        if(despawn == true)
        {
            enemytodespawn.SetActive(false);
        }
        EnenytoSpawn.SetActive(true);
        enemyspawnaudio.Play();
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
