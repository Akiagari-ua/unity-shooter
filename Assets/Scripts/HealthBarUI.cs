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
}