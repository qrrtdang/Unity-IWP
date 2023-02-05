using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundeffect : MonoBehaviour
{
    public AudioSource run;
    public AudioSource run2;
    public AudioSource attacksound;
    public AudioSource attacksound1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void walksound()
    {
        run.Play();
    }

    void walksound2()
    {
        run2.Play();
    }

    void attack()
    {
        attacksound.Play();
    }
    void attack1()
    {
        attacksound1.Play();
    }
}
