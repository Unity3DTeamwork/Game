using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    private int MinDist = 10;

    
    private GameObject Player;

    private Animator animator;

    private int MoveSpeed = 20;

    // Use this for initialization
    void Start()
    {

        this.Player = GameObject.FindGameObjectWithTag("Player");

        this.animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.LookAt(this.Player.transform);

            if (Vector3.Distance(transform.position, this.Player.transform.position) <= this.MinDist)
            {
                this.animator.SetBool("Attack", true);
                this.animator.SetBool("Moving", false);
            }
            else
            {
                this.animator.SetBool("Attack", false);
                this.animator.SetBool("Moving", true);
            }
        }
    }
}