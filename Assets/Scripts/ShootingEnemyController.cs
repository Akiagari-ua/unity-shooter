using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemyController : MonoBehaviour
{
    public Transform target; // Игрок
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint; // Точка, из которой вылетают пули
    public float fireRate = 2f; // Задержка между выстрелами
    public float detectionRange = 45f; // Дистанция обнаружения игрока
    public float shootingRange = 30;// Дистанция стрельбы
    public float bulletSpeed = 10f; // Скорость пули

    private NavMeshAgent navMeshAgent;
    private float nextFireTime = 0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 3.5f; // Установите скорость врага
    }

    void Update()
    {
        if (target == null) return;

        // Рассчитываем дистанцию до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        // Если игрок находится в зоне обнаружения, враг начинает движение к нему
        if (distanceToPlayer <= detectionRange)
        {
            // Если враг находится вне зоны стрельбы, он продолжает движение к игроку
            if (distanceToPlayer > shootingRange)
            {
                navMeshAgent.isStopped = false; // Включаем движение
                navMeshAgent.SetDestination(target.position);
            }
            else
            {
                // Останавливаем врага и поворачиваем его к игроку
                navMeshAgent.isStopped = true;

                Vector3 lookDirection = target.position - transform.position;
                lookDirection.y = 0; // Игнорируем высоту
                transform.rotation = Quaternion.LookRotation(lookDirection);


                // Если прошло достаточно времени, враг стреляет
                if (Time.time >= nextFireTime)
                {
                   
                    Debug.Log("Time: " + Time.time);
                    Debug.Log("FireRate: " + fireRate);
                    Shoot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        
        if (bulletScript != null)
        {
            bulletScript.speed = bulletSpeed;
        }
    }
}
