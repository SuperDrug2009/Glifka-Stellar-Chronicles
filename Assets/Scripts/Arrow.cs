using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Arrow : MonoBehaviour
{
    public Transform target; // Объект, за которым нужно следить

    public float initialZRotation = -90f; // Начальное значение оси Z

    void Update()
    {
        if (target != null)
        {
            // Получаем направление к цели
            Vector3 direction = target.position - transform.position;

            // Вычисляем угол между направлением и осью X
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Устанавливаем вращение объекта UI по оси Z с учетом начального значения
            transform.rotation = Quaternion.Euler(0, 0, angle + initialZRotation);
        }
    }
}
