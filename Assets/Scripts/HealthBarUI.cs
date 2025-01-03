using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider; // Ссылка на Slider, отвечающий за заполнение
    public Transform target; // Цель, над которой находится полоска

    void Start()
    {
        healthSlider.value = 1f; // Заполнение полоски на 100%
    }

    public void SetHealth(float healthPercent)
    {
        Debug.Log("SetHealth: " + healthPercent);
       healthSlider.value = healthPercent; // Устанавливаем значение полоски
    }

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