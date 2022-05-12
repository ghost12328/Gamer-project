using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    //variables for the player
    public Transform player;
    public float playerMinDistance = .05f;
    public float playerMaxDistance = 5f;
    //int health = 10;
    //variables for the pathfinding
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public float minDistance = .05f;
    public float enemySpeed = 3f;

    //variables for animations
    private Animator animator;

    [SerializeField] [Header("Enemy Health")]
    public float enemyHealth = 100f; 

    [SerializeField] [Header("Enemy Damage Taken")]
     public float damageEnemy = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //gets the animator attatched to the game object (the 2 enemies use different animators)
        animator = GetComponent<Animator>();
        //Walking Animation
        animator.SetFloat("speed", 1);
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();

    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        //checks to see if the player is in range, otherwise continue along path
        if (Vector3.Distance(player.transform.position, transform.position) < playerMaxDistance)
        {
            agent.destination = player.transform.position;
            if (Vector3.Distance(player.transform.position, transform.position) < playerMinDistance)
            {
                //Attack animation
                animator.SetBool("nearPlayer", true);
                agent.speed = 0;
            }
        }
        else
        {
            animator.SetBool("nearPlayer", false);
            agent.speed = enemySpeed;
            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;
            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            agent.speed = 0;
            //set death animation 
            animator.Play("die");
            animator.Play("Fall1");
            // Destroy(gameObject);
            Destroy(this.gameObject, 6);
        }
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        //distance = Vector3.Distance(transform.position, player.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            enemyHealth -= 1;
            //hit animation
            animator.SetTrigger("getHit");

            
        }
    }
    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if (enemyHealth <= 0)
        {
            EnemyDead();
        }
    }
    public void EnemyDead()
    {
        // Animation.Play("");
        // play dealth animation 
        animator.SetInteger("Hp", 0);
        // Destroy(this.gameObject, seconds delay);
        Destroy(this.gameObject, 6);
        // destroys enemy 
    }
}
