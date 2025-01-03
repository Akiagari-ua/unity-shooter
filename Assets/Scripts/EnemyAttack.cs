using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10; // Урон, который наносит враг
    public float attackCooldown = 2f; // Задержка между атаками
    private float lastAttackTime;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(lastAttackTime);
        if (other.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
}