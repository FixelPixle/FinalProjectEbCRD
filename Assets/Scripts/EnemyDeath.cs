using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour
{
    public int EnemyHealth = 20;
    public AnimationClip deathAnimationClip; // Assign this in the Inspector
    public bool isDead = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DamageEnemy(int DamageAmount)
    {
        if (isDead) return;

        EnemyHealth -= DamageAmount;

        if (EnemyHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");

        // Optionally disable enemy's collider to prevent further interactions
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        // Wait for the death animation to finish
        yield return new WaitForSeconds(deathAnimationClip.length);

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}