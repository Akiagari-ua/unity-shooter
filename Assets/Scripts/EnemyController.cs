using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target; // Цель (игрок)
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            // Устанавливаем позицию игрока как цель
            navMeshAgent.SetDestination(target.position);

            // Проверяем, если враг случайно развернулся спиной
            Vector3 lookDirection = target.position - transform.position;
            lookDirection.y = 0; // Игнорируем высоту

            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }
}
