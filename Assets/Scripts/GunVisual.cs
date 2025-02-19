using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunVisual : MonoBehaviour
{
    public float minRotationY = 500f; // Минимальный угол вращения по оси Y
    public float maxRotationY = 515f; // Максимальный угол вращения по оси Y
    public float rotationSpeed = 5f; // Скорость вращения (угол в градусах в секунду)
    public bool Clicked;
    public Button button;

    public BallMovement ball;
    public PowerMeter meter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RotateZ());
        }


        if (!Clicked)
        {
            // Рассчитываем текущее значение угла вращения с использованием PingPong
            float angle = Mathf.PingPong(Time.time * rotationSpeed, maxRotationY - minRotationY) + minRotationY;

            // Применяем вращение к объекту
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }


        
        
    }

    public void StartCor()
    {
        StartCoroutine(RotateZ());
        button.interactable = false;
    }



    public float duration = 5.0f; // Время, за которое нужно будет изменить угол
    
    public float secondDuration = 2.0f;


    private IEnumerator RotateZ()
    {
        meter.GetForceByHit();
        meter.isPaused = true;
        //meter.StartCoroutine(meter.FadeAlpha());
        Clicked = true;
        float startZ = transform.rotation.eulerAngles.z; // Начальное значение
        float endZ = 54f;   // Конечное значение
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newZ = Mathf.Lerp(startZ, endZ, elapsedTime / duration);
            transform.rotation = Quaternion.Euler(0, 0, newZ);
            elapsedTime += Time.deltaTime;
            yield return null; // Ждем следующий кадр
        }
        
        startZ = transform.rotation.eulerAngles.z;
        elapsedTime = 0f;
        
        float endZ2 = 277f;

        // Второй поворот
        while (elapsedTime < secondDuration)
        {
            float newZ = Mathf.Lerp(startZ, endZ2, elapsedTime / secondDuration);
            transform.rotation = Quaternion.Euler(0, 0, newZ);
            elapsedTime += Time.deltaTime;
            
            ball.ApplyHit();
            meter.ChangeActive(false);
            
            yield return null; // Ждем следующий кадр
        }
        AudioSystem.Instance.HITBALLSOUNS.PlayOneShot(AudioSystem.Instance.HITBALLSOUNS.clip);
        StopCoroutine(RotateZ());

    }
}


