using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunVisual : MonoBehaviour
{
    public float minRotationY = 500f; // ����������� ���� �������� �� ��� Y
    public float maxRotationY = 515f; // ������������ ���� �������� �� ��� Y
    public float rotationSpeed = 5f; // �������� �������� (���� � �������� � �������)
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
            // ������������ ������� �������� ���� �������� � �������������� PingPong
            float angle = Mathf.PingPong(Time.time * rotationSpeed, maxRotationY - minRotationY) + minRotationY;

            // ��������� �������� � �������
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }


        
        
    }

    public void StartCor()
    {
        StartCoroutine(RotateZ());
        button.interactable = false;
    }



    public float duration = 5.0f; // �����, �� ������� ����� ����� �������� ����
    
    public float secondDuration = 2.0f;


    private IEnumerator RotateZ()
    {
        meter.GetForceByHit();
        meter.isPaused = true;
        //meter.StartCoroutine(meter.FadeAlpha());
        Clicked = true;
        float startZ = transform.rotation.eulerAngles.z; // ��������� ��������
        float endZ = 54f;   // �������� ��������
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newZ = Mathf.Lerp(startZ, endZ, elapsedTime / duration);
            transform.rotation = Quaternion.Euler(0, 0, newZ);
            elapsedTime += Time.deltaTime;
            yield return null; // ���� ��������� ����
        }
        
        startZ = transform.rotation.eulerAngles.z;
        elapsedTime = 0f;
        
        float endZ2 = 277f;

        // ������ �������
        while (elapsedTime < secondDuration)
        {
            float newZ = Mathf.Lerp(startZ, endZ2, elapsedTime / secondDuration);
            transform.rotation = Quaternion.Euler(0, 0, newZ);
            elapsedTime += Time.deltaTime;
            
            ball.ApplyHit();
            meter.ChangeActive(false);
            
            yield return null; // ���� ��������� ����
        }
        AudioSystem.Instance.HITBALLSOUNS.PlayOneShot(AudioSystem.Instance.HITBALLSOUNS.clip);
        StopCoroutine(RotateZ());

    }
}


