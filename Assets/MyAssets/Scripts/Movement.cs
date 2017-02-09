using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    Animator anim;
    bool playerInRange;

    public float attackRate;
    private float nextAttack;

    public int attackDamage;
    public int attackDistance;
    PlayerAttributes playerHealth;                  // Reference to the player's health.

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerAttributes>();
    }

    //Default unity function for when a rigidbody collides with another object with a collider
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {   //Check if collided object is a bullet
            Debug.Log("Collision Enter");
            anim.SetBool("inAttackRange", true);
            playerInRange = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.transform.tag== "Player")
        {   //Check if collided object is a bullet
            Debug.Log("Collision Exit");
            anim.SetBool("inAttackRange", false);
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
       
        if (dist < attackDistance && playerInRange && Time.time > nextAttack)
        {
            
            //Debug.Log("Attack!!");
            if (dist < attackDistance )
            {
                nextAttack = Time.time + attackRate;
                playerHealth.TakeDamage(attackDamage);
            }   
        }
        else
        {
            
            //anim.SetBool("inAttackRange", false);
        }
        nav.SetDestination(player.position);
    }
}
