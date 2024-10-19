using System.Collections;
using UnityEngine;

public class PistolShot : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject MuzzleFlash;
    public bool IsFiring = false;
    public float TargetDistance;
    public int DamageAmount = 5;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GlobalAmmo.CurrentAmmo >= 1)
        {
            if (!IsFiring)
            {
                GlobalAmmo.CurrentAmmo -= 1;
                StartCoroutine(FiringPistol());
            }
        }
    }

    IEnumerator FiringPistol()
    {
        IsFiring = true;

        // Play pistol firing animation
        Animation animation = Pistol.GetComponent<Animation>();
        animation.Play();

        // Show muzzle flash
        MuzzleFlash.SetActive(true);

        // Raycast to detect hit, ignoring the UI layer
        RaycastHit hit;
        int layerMask = ~LayerMask.GetMask("UI"); // Invert mask to hit everything except UI layer

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            TargetDistance = hit.distance;

            // Check if the hit object has the EnemyDeath component
            EnemyDeath enemy = hit.transform.GetComponent<EnemyDeath>();
            if (enemy != null)
            {
                enemy.DamageEnemy(DamageAmount);
            }
            VaseBreak vase = hit.transform.GetComponent<VaseBreak>();
            if (vase != null)
            {
                vase.BreakVase();
            }
        }

        yield return new WaitForSeconds(0.5f);

        // Hide muzzle flash
        MuzzleFlash.SetActive(false);
        IsFiring = false;
    }
}