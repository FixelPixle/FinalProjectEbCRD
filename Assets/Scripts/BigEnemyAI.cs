using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyAI : MonoBehaviour
{
    public GameObject BigEnemyDestination; // This is the player
    NavMeshAgent BigEnemyAgent;
    public GameObject BigEnemy;
    public static bool isFollowing;
    private Animator bigEnemyAnimator;
    public float attackDistance = 4f; 
    public float attackCooldown = 2f; 
    private float nextAttackTime = 0f;
    public float attackDelay = 0f; // Time before damage is applied (e.g., after the attack animation)
    private bool isAttacking = false; // Track if the enemy is currently in the middle of an attack
    private Vector3 startingPosition; 

    // Start is called before the first frame update
    void Start()
    {
        BigEnemyAgent = GetComponent<NavMeshAgent>();
        bigEnemyAnimator = BigEnemy.GetComponentInChildren<Animator>();
        startingPosition = transform.position; // Capture the enemy's starting position
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, BigEnemyDestination.transform.position);
        float distanceToStart = Vector3.Distance(transform.position, startingPosition); // Distance to start position

        if (!isFollowing)
        {
            if (distanceToStart > 0.5f) // If the enemy is not at its starting position
            {
                bigEnemyAnimator.Play("Mutant Walking"); // Play walking animation while returning
                BigEnemyAgent.isStopped = false; // Allow movement to the starting position
                BigEnemyAgent.SetDestination(startingPosition); // Move back to the starting position
            }
            else
            {
                bigEnemyAnimator.Play("Mutant Idle"); // Once it reaches the starting position, play idle animation
            }
        }
        else
        {
            BigEnemyAgent.isStopped = false; // Resume the agent's movement
            if (distanceToPlayer > attackDistance)
            {
                // Enemy is far from the player, move towards the player
                bigEnemyAnimator.Play("Mutant Walking");
                BigEnemyAgent.SetDestination(BigEnemyDestination.transform.position);
            }
            else if (distanceToPlayer <= attackDistance && Time.time >= nextAttackTime && !isAttacking)
            {
                // Enemy is close enough to attack the player
                bigEnemyAnimator.Play("Mutant Swiping");
                StartCoroutine(DelayedAttack()); // Start the delayed attack
                nextAttackTime = Time.time + attackCooldown; // Reset the cooldown
            }
        }
    }

    // Coroutine to delay the damage after the attack animation
    IEnumerator DelayedAttack()
    {
        isAttacking = true; // Mark as attacking to prevent multiple attacks
        yield return new WaitForSeconds(attackDelay); // Wait for the delay
        if (Vector3.Distance(transform.position, BigEnemyDestination.transform.position) <= attackDistance)
        {
            // Apply damage if the player is still within range
            AttackPlayer();
        }
        isAttacking = false; // Attack finished
    }

    void AttackPlayer()
    {
        // Damage the player instantly
        GlobalHealth.PlayerHealth -= 20;
    }
}
