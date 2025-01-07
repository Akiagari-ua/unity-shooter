using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10; // Урон, который наносит враг
    public float attackCooldown = 2f; // Задержка между атаками
    private float lastAttackTime;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown)
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
}