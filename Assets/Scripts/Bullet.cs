using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Скорость пули
    public int damage = 10; // Урон от пули
    public float lifeTime = 3f; // Время жизни пули (в секундах)

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Перемещаем пулю вперед с заданной скоростью
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        // Уничтожаем пулю при столкновении
        Destroy(gameObject);
    }
}
