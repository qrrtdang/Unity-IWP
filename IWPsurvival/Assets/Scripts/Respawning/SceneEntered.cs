using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntered : MonoBehaviour
{
    public static int sceneNumber=0;
    [SerializeField] private int sceneNumber1;

    void Start()
    {
        sceneNumber = sceneNumber + sceneNumber1;
    }

   
}
