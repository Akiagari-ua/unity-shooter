using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    private Rigidbody rb; // Компонент Rigidbody для работы с физикой

    private Vector3 moveDirection; // Направление движения персонажа
    private Camera mainCamera; // Главная камера для расчета направления мыши

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main; // Инициализация главной камеры
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Поворот персонажа за мышкой
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            Vector3 lookDirection = hitInfo.point - transform.position;
            lookDirection.y = 0; // Игнорируем высоту
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}