using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        // Обновление позиции полоски над врагом
        if (target != null)
        {
            Vector3 offsetPosition = target.position + new Vector3(0, 2f, 0); // Смещаем полоску вверх
            transform.position = offsetPosition;
            transform.rotation = Camera.main.transform.rotation; // Поворачиваем полоску к камере
        }
    }
}
