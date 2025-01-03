using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Скорость движения врага
    public Transform target; // Цель, за которой следует враг (например, игрок)
    public Transform frontPoint; // Точка, определяющая "перед" врага

    void Update()
    {
        if (target != null)
        {
            // Движение врага к цели
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Поворот врага к цели относительно frontPoint
            Vector3 lookDirection = target.position - frontPoint.position;
            lookDirection.y = 0; // Убираем изменение по оси Y
            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }
}