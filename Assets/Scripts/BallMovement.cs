using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public PowerMeter powerMeter;
    public Rigidbody2D rb; // Ссылка на Rigidbody2D объекта
    public float hitForce = 10f; // Сила удара
    public float angle = 45f; // Угол удара в градусах
    private bool isHit = false; // Флаг для отслеживания, был ли удар
    public PhysicsMaterial2D ballMaterial;
    public Upgrader bounceUpgrader;
    public Image image;
    public ProgressBar progressBar;

    public float maxDistance; //= 23f;
    public RectTransform indicator;

    private void Update()
    {
        maxDistance = progressBar.recordSaved;
        ballMaterial.bounciness = bounceUpgrader.currentValue;
        hitForce = powerMeter.CurrentPower;
        angle = powerMeter.CurrentAngle;



        if (image != null && transform != null)
        {
            // Вычисляем заполнение в зависимости от позиции целевого объекта
            float fillAmount = Mathf.Clamp01(transform.position.x * 0.2f / maxDistance);
            image.fillAmount = fillAmount;

            float fillWidth = image.rectTransform.rect.width; // Ширина компонента fillImage

            // Индикатор будет двигаться от левой границы fillImage
            float indicatorPositionX = (fillWidth * fillAmount) - (fillWidth / 2);

            // Обновляем позицию индикатора, используя локальные координаты
            indicator.localPosition = new Vector3(indicatorPositionX, indicator.localPosition.y, indicator.localPosition.z);

        }


    }

    int touches = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("_ground"))
        {
            touches++;
            if (touches == 3)
            {
                rb.sharedMaterial = null;
            }
        }
    }


    private void Start()
    {
        image.rectTransform.position = image.rectTransform.position;
    }


    public void ApplyHit()
    {
        
        // Вычисляем направление удара на основе угла
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        // Применяем силу к Rigidbody2D
        rb.AddForce(direction * hitForce * Time.deltaTime, ForceMode2D.Impulse);
        //rb.angularVelocity = 0;
        // Устанавливаем флаг, что удар был нанесен
        isHit = true;
    }

    // Метод для сброса флага удара (можно вызывать из другого скрипта или по таймеру)
    public void ResetHit()
    {
        isHit = false;
    }
}
