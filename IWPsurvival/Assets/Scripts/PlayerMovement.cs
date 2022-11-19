using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public AudioSource walkingsound;
    public float jumpheight = 3f;

    Vector3 velocity;
    bool isGrounded;
    bool audioisplaying;
    bool isjumped;

   

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        //if(walkingsound.isPlaying)
        //{
        //    audioisplaying = true;
        //    Debug.Log("walking sound isplaying");
        //}

        //if (!walkingsound.isPlaying)
        //{
        //    audioisplaying = false;
        //    Debug.Log("walking sound is not playing");
        //}


        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && !isjumped && isGrounded)
        {
            StartCoroutine(Playwalkingsound());

        }
        else
        {
            walkingsound.enabled = false;
            
        }

        



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward *z;

        controller.Move(move*speed*Time.deltaTime);

      

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight*-2*gravity);
            isjumped = true;
            walkingsound.enabled = false;

        }
        else
        {
            isjumped = false;
        }

        if (isjumped == true)
        {
            walkingsound.enabled = false;
        }

        if(isGrounded==false)
        {
            walkingsound.enabled = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    IEnumerator Playwalkingsound()
    {
        yield return new WaitForSeconds(0.35f);
        walkingsound.enabled = true;

    }
    
    

    
}
