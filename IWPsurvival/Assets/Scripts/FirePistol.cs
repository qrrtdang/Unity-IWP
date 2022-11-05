using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public GameObject GunLight;
    public AudioSource GunFire;
    public bool IsFiring = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(IsFiring == false)
            {
                StartCoroutine(FiringPistol());
            }
            
        }
    }

    IEnumerator FiringPistol()
    {
        IsFiring = true;
        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        GunLight.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        GunLight.GetComponent<Animation>().Play("LightVanish");
        GunFire.Play();
        yield return new WaitForSeconds(0.3f);
        IsFiring = false;
    }
}
