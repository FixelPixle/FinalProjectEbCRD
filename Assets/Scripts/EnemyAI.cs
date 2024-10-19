using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    public float EnemyMovementSpeed = 2.0f; // Units per second
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public GameObject DamageFlash;

    private Animator animator;
    private EnemyDeath enemyDeath;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyDeath = GetComponent<EnemyDeath>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (enemyDeath.isDead)
        {
            // Stop movement
            return;
        }

        // Face the player
        Vector3 direction = (Player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        rb.MoveRotation(lookRotation);

        if (!attackTrigger && !isAttacking)
        {
            // Move towards the player using Rigidbody.MovePosition
            Vector3 moveDirection = direction * EnemyMovementSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveDirection);
        }

        if (attackTrigger && !isAttacking)
        {
            StartCoroutine(EnemyDamage());
        }
    }

    IEnumerator EnemyDamage()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");

        // Wait for the attack animation to reach the point of impact
        yield return new WaitForSeconds(0.7f); // Adjust based on your animation timing

        // Apply damage to the player if the enemy is still alive and player is in range
        if (!enemyDeath.isDead && attackTrigger)
        {
            DamageFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            GlobalHealth.PlayerHealth -= 5;
            DamageFlash.SetActive(false);
            
        }

        // Wait for the rest of the attack animation to finish
        yield return new WaitForSeconds(0.9f); // Adjust as needed (1.4f total - 0.5f)

        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            attackTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            attackTrigger = false;
        }
    }
}
