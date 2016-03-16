using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour
{

    Animator animator; //stores the animator component

     Animation attack ;
    float v; //vertical movements

    float h; //horizontal movements
    int[] stateHashes = new int[5];
    float sprint;
    float rotateSpeed = 10f;
    void Start()
    {

        animator = GetComponent<Animator>(); //assigns Animator component when we start the game
       
    }

    void Update()
    {
this.Attack();
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
      
        
       
transform.Rotate(0f, Input.GetAxis("Mouse X") * rotateSpeed, 0f);
    }

    void FixedUpdate()
    {

        //set the "Walk" parameter to the v axis value
        animator.SetFloat("Walk", v);
        animator.SetFloat("Turn", h);

    }

    void Attack()
    {
         if (Input.GetMouseButtonDown(0))
         {
            this.animator.SetFloat("Attack" , 1.0f);
         }
         if (Input.GetMouseButtonUp(0))
         {
             this.animator.SetFloat("Attack", 0.0f);
         }
       
        
    }
    
}
