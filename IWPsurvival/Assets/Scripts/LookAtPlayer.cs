using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        var rot = transform.eulerAngles;
        rot.x = 0;
        transform.eulerAngles = rot;

    }



}
