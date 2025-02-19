using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDistance : MonoBehaviour
{
    public Transform ball; // Объект мяча
    public Camera mainCamera; // Главная камера

    public float minCameraSize = 10f; // Минимальный размер камеры (начальный размер)
    public float maxCameraSize = 20f; // Максимальный размер камеры
    public float smoothTime = 0.3f; // Время сглаживания для перемещения камеры
    public float sizeLerpSpeed = 2f; // Скорость изменения размера камеры
    public float minYBoundary = -6.87f; // Минимальная граница по Y, которую камера НЕ должна показывать

    private Vector3 velocity = Vector3.zero; // Скорость сглаживания
    private float maxHeight = 0f; // Максимальная высота, на которой мяч находился

    void Start()
    {
        if (ball == null || mainCamera == null)
        {
            Debug.LogError("Не назначены объекты мяча или камеры.");
            return;
        }
    }

    void LateUpdate()
    {
        FollowBall();
        AdjustCameraSize();
    }

    private void FollowBall()
    {
        // Вычисляем целевую позицию камеры по оси X
        float targetX = ball.position.x;

        // Вычисляем минимальную позицию камеры по оси Y, чтобы нижняя граница не опускалась ниже minYBoundary
        float cameraBottomY = minYBoundary + mainCamera.orthographicSize;
        float targetY = Mathf.Max(ball.position.y, cameraBottomY);

        // Устанавливаем целевую позицию камеры
        Vector3 targetPosition = new Vector3(
            targetX, // Следование по оси X
            targetY, // Ограничиваем минимальную позицию по Y
            mainCamera.transform.position.z // Оставляем Z без изменений
        );

        // Плавно перемещаем камеру к целевой позиции
        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void AdjustCameraSize()
    {
        if (ball == null || mainCamera == null)
        {
            Debug.LogError("Не назначены объекты мяча или камеры.");
            return;
        }

        // Получаем текущую высоту мяча относительно земли
        float currentHeight = ball.position.y;

        // Обновляем максимальную высоту мяча
        if (currentHeight > maxHeight)
        {
            maxHeight = currentHeight;
        }

        // Нормализуем высоту мяча в диапазоне от 0 до 1 относительно максимальной высоты
        float normalizedHeight = Mathf.Clamp01(currentHeight / maxHeight);

        // Линейно интерполируем размер камеры между минимальным и максимальным значениями
        float cameraSize = Mathf.Lerp(minCameraSize, maxCameraSize, normalizedHeight);

        // Если мяч снижается, уменьшаем размер камеры обратно к минимальному значению
        if (currentHeight < maxHeight)
        {
            cameraSize = Mathf.Lerp(maxCameraSize, minCameraSize, (maxHeight - currentHeight) / maxHeight);
        }

        // Устанавливаем новый размер камеры с сглаживанием
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, cameraSize, Time.deltaTime * sizeLerpSpeed);
    }

    //public Transform ball; // Объект мяча
    //public Camera mainCamera; // Главная камера

    //public float minCameraSize = 10f; // Минимальный размер камеры (начальный размер)
    //public float maxCameraSize = 20f; // Максимальный размер камеры

    //public float yOffset = 0f; // Отступ по оси Y от позиции мяча
    //public float smoothTime = 0.3f; // Время сглаживания для перемещения камеры
    //private Vector3 velocity = Vector3.zero; // Скорость сглаживания

    //private Vector3 lastBallPosition; // Последняя позиция мяча для определения направления движения
    //private float maxHeight = 0f; // Максимальная высота, на которой мяч находился
    //private float initialYPosition; // Исходная позиция камеры по оси Y




    
    //void Start()
    //{
    //    if (ball == null || mainCamera == null)
    //    {
    //        Debug.LogError("Не назначены объекты мяча или камеры.");
    //        return;
    //    }

    //    // Запоминаем начальную позицию мяча
    //    lastBallPosition = ball.position;

    //    // Запоминаем исходную позицию камеры по оси Y
    //    initialYPosition = mainCamera.transform.position.y - mainCamera.orthographicSize;
    //}

    //void Update()
    //{
    //    FollowBall();
    //    AdjustCameraSize();
    //}

    //private void FollowBall()
    //{
    //    // Вычисляем целевую позицию камеры по осям X и Y
    //    Vector3 targetPosition = new Vector3(
    //        ball.position.x, // Следование по оси X
    //        CalculateTargetYPosition(), // Следование по оси Y с учетом изменения размера камеры
    //        mainCamera.transform.position.z // Оставляем Z без изменений
    //    );

    //    // Плавно перемещаем камеру к целевой позиции
    //    mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref velocity, smoothTime);
    //}

    //private float CalculateTargetYPosition()
    //{
    //    // Вычисляем целевую позицию камеры по оси Y, чтобы нижняя граница камеры оставалась на одном месте
    //    return initialYPosition + mainCamera.orthographicSize;
    //}

    //private void AdjustCameraSize()
    //{
    //    if (ball == null || mainCamera == null)
    //    {
    //        Debug.LogError("Не назначены объекты мяча или камеры.");
    //        return;
    //    }

    //    // Получаем текущую высоту мяча относительно земли
    //    float currentHeight = ball.position.y;

    //    // Определяем направление движения мяча по оси Y
    //    bool isMovingUp = ball.position.y > lastBallPosition.y;

    //    // Обновляем максимальную высоту мяча с небольшой задержкой
    //    if (isMovingUp && currentHeight > maxHeight)
    //    {
    //        maxHeight = currentHeight;
    //    }

    //    // Нормализуем высоту мяча в диапазоне от 0 до 1 относительно максимальной высоты
    //    float normalizedHeight = Mathf.Clamp01(currentHeight / maxHeight);

    //    // Линейно интерполируем размер камеры между минимальным и максимальным значениями
    //    float cameraSize = Mathf.Lerp(minCameraSize, maxCameraSize, normalizedHeight);

    //    // Если мяч начал снижаться, уменьшаем размер камеры линейно обратно к минимальному значению
    //    if (!isMovingUp && currentHeight < maxHeight)
    //    {
    //        cameraSize = Mathf.Lerp(maxCameraSize, minCameraSize, (maxHeight - currentHeight) / maxHeight);
    //    }

    //    // Устанавливаем новый размер камеры с сглаживанием
    //    mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, cameraSize, Time.deltaTime * 5f);

    //    // Обновляем последнюю позицию мяча
    //    lastBallPosition = ball.position;
    //}

}
