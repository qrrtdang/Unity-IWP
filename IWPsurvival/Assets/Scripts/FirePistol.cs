using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public GameObject MuzzleFlash2;
    public GameObject GunLight;
    public AudioSource GunFire;
    public GameObject Blood;
    public bool IsFiring = false;
    public float TargetDistance;
    public int DamageAmount = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&& GlobalAmmo.ammoCount>=1)
        {
            if(IsFiring == false)
            {
                GlobalAmmo.ammoCount -= 1;
                StartCoroutine(FiringPistol());
            }
            
        }
    }

    IEnumerator FiringPistol()
    {
        RaycastHit Shot;
        IsFiring = true;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageMonster", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        if(Shot.transform.tag=="Enemy")
        {
            TargetDistance = Shot.distance;
            Instantiate(Blood, Shot.point, Quaternion.FromToRotation(Vector3.up, Shot.normal));
            Debug.Log("Enemy is shot");
        }
        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        MuzzleFlash2.SetActive(true);
        GunLight.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        GunLight.GetComponent<Animation>().Play("LightVanish");
        MuzzleFlash2.GetComponent<Animation>().Play("Muzzlelightvanish");
        GunFire.Play();
        yield return new WaitForSeconds(0.3f);
        IsFiring = false;
    }
}
