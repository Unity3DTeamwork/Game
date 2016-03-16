using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour
{

    Animator animator; //stores the animator component

    float v; //vertical movements

    float h; //horizontal movements

    float sprint;
    
    void Start()
    {

        animator = GetComponent<Animator>(); //assigns Animator component when we start the game

    }

    void Update()
    {

        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        Sprinting();
       

    }

    void FixedUpdate()
    {

        //set the "Walk" parameter to the v axis value
        animator.SetFloat("Walk", v);
        animator.SetFloat("Turn", h);
        animator.SetFloat("Sprint", sprint);

    }

    void Sprinting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sprint = 1f;
        }
        else
        {

            sprint = 0.0f;
        }
    }
}
