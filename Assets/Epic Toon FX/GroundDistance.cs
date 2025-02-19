using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDistance : MonoBehaviour
{
    public Transform ball; // ������ ����
    public Camera mainCamera; // ������� ������

    public float minCameraSize = 10f; // ����������� ������ ������ (��������� ������)
    public float maxCameraSize = 20f; // ������������ ������ ������
    public float smoothTime = 0.3f; // ����� ����������� ��� ����������� ������
    public float sizeLerpSpeed = 2f; // �������� ��������� ������� ������
    public float minYBoundary = -6.87f; // ����������� ������� �� Y, ������� ������ �� ������ ����������

    private Vector3 velocity = Vector3.zero; // �������� �����������
    private float maxHeight = 0f; // ������������ ������, �� ������� ��� ���������

    void Start()
    {
        if (ball == null || mainCamera == null)
        {
            Debug.LogError("�� ��������� ������� ���� ��� ������.");
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
        // ��������� ������� ������� ������ �� ��� X
        float targetX = ball.position.x;

        // ��������� ����������� ������� ������ �� ��� Y, ����� ������ ������� �� ���������� ���� minYBoundary
        float cameraBottomY = minYBoundary + mainCamera.orthographicSize;
        float targetY = Mathf.Max(ball.position.y, cameraBottomY);

        // ������������� ������� ������� ������
        Vector3 targetPosition = new Vector3(
            targetX, // ���������� �� ��� X
            targetY, // ������������ ����������� ������� �� Y
            mainCamera.transform.position.z // ��������� Z ��� ���������
        );

        // ������ ���������� ������ � ������� �������
        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void AdjustCameraSize()
    {
        if (ball == null || mainCamera == null)
        {
            Debug.LogError("�� ��������� ������� ���� ��� ������.");
            return;
        }

        // �������� ������� ������ ���� ������������ �����
        float currentHeight = ball.position.y;

        // ��������� ������������ ������ ����
        if (currentHeight > maxHeight)
        {
            maxHeight = currentHeight;
        }

        // ����������� ������ ���� � ��������� �� 0 �� 1 ������������ ������������ ������
        float normalizedHeight = Mathf.Clamp01(currentHeight / maxHeight);

        // ������� ������������� ������ ������ ����� ����������� � ������������ ����������
        float cameraSize = Mathf.Lerp(minCameraSize, maxCameraSize, normalizedHeight);

        // ���� ��� ���������, ��������� ������ ������ ������� � ������������ ��������
        if (currentHeight < maxHeight)
        {
            cameraSize = Mathf.Lerp(maxCameraSize, minCameraSize, (maxHeight - currentHeight) / maxHeight);
        }

        // ������������� ����� ������ ������ � ������������
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, cameraSize, Time.deltaTime * sizeLerpSpeed);
    }

    //public Transform ball; // ������ ����
    //public Camera mainCamera; // ������� ������

    //public float minCameraSize = 10f; // ����������� ������ ������ (��������� ������)
    //public float maxCameraSize = 20f; // ������������ ������ ������

    //public float yOffset = 0f; // ������ �� ��� Y �� ������� ����
    //public float smoothTime = 0.3f; // ����� ����������� ��� ����������� ������
    //private Vector3 velocity = Vector3.zero; // �������� �����������

    //private Vector3 lastBallPosition; // ��������� ������� ���� ��� ����������� ����������� ��������
    //private float maxHeight = 0f; // ������������ ������, �� ������� ��� ���������
    //private float initialYPosition; // �������� ������� ������ �� ��� Y




    
    //void Start()
    //{
    //    if (ball == null || mainCamera == null)
    //    {
    //        Debug.LogError("�� ��������� ������� ���� ��� ������.");
    //        return;
    //    }

    //    // ���������� ��������� ������� ����
    //    lastBallPosition = ball.position;

    //    // ���������� �������� ������� ������ �� ��� Y
    //    initialYPosition = mainCamera.transform.position.y - mainCamera.orthographicSize;
    //}

    //void Update()
    //{
    //    FollowBall();
    //    AdjustCameraSize();
    //}

    //private void FollowBall()
    //{
    //    // ��������� ������� ������� ������ �� ���� X � Y
    //    Vector3 targetPosition = new Vector3(
    //        ball.position.x, // ���������� �� ��� X
    //        CalculateTargetYPosition(), // ���������� �� ��� Y � ������ ��������� ������� ������
    //        mainCamera.transform.position.z // ��������� Z ��� ���������
    //    );

    //    // ������ ���������� ������ � ������� �������
    //    mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref velocity, smoothTime);
    //}

    //private float CalculateTargetYPosition()
    //{
    //    // ��������� ������� ������� ������ �� ��� Y, ����� ������ ������� ������ ���������� �� ����� �����
    //    return initialYPosition + mainCamera.orthographicSize;
    //}

    //private void AdjustCameraSize()
    //{
    //    if (ball == null || mainCamera == null)
    //    {
    //        Debug.LogError("�� ��������� ������� ���� ��� ������.");
    //        return;
    //    }

    //    // �������� ������� ������ ���� ������������ �����
    //    float currentHeight = ball.position.y;

    //    // ���������� ����������� �������� ���� �� ��� Y
    //    bool isMovingUp = ball.position.y > lastBallPosition.y;

    //    // ��������� ������������ ������ ���� � ��������� ���������
    //    if (isMovingUp && currentHeight > maxHeight)
    //    {
    //        maxHeight = currentHeight;
    //    }

    //    // ����������� ������ ���� � ��������� �� 0 �� 1 ������������ ������������ ������
    //    float normalizedHeight = Mathf.Clamp01(currentHeight / maxHeight);

    //    // ������� ������������� ������ ������ ����� ����������� � ������������ ����������
    //    float cameraSize = Mathf.Lerp(minCameraSize, maxCameraSize, normalizedHeight);

    //    // ���� ��� ����� ���������, ��������� ������ ������ ������� ������� � ������������ ��������
    //    if (!isMovingUp && currentHeight < maxHeight)
    //    {
    //        cameraSize = Mathf.Lerp(maxCameraSize, minCameraSize, (maxHeight - currentHeight) / maxHeight);
    //    }

    //    // ������������� ����� ������ ������ � ������������
    //    mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, cameraSize, Time.deltaTime * 5f);

    //    // ��������� ��������� ������� ����
    //    lastBallPosition = ball.position;
    //}

}
