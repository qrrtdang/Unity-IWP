using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZJumpTrigger : MonoBehaviour
{
    public AudioSource Doorbang;
    //public AudioSource JumpMusic;
    public GameObject Monster;
    public GameObject TheDoor;

    void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpDorrAnim");
        Doorbang.Play();
        Monster.SetActive(true);
        //StartCoroutine(PlayJumpMusic());
    }
    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        //JumpMusic.Play();
    }
}
