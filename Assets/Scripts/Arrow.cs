using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Arrow : MonoBehaviour
{
    public Transform target; // ������, �� ������� ����� �������

    public float initialZRotation = -90f; // ��������� �������� ��� Z

    void Update()
    {
        if (target != null)
        {
            // �������� ����������� � ����
            Vector3 direction = target.position - transform.position;

            // ��������� ���� ����� ������������ � ���� X
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // ������������� �������� ������� UI �� ��� Z � ������ ���������� ��������
            transform.rotation = Quaternion.Euler(0, 0, angle + initialZRotation);
        }
    }
}
