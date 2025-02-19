using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//[ExecuteAlways]
public class PowerMeter : MonoBehaviour
{

    public GameObject MeterUi;
    public float duration = 0.65f; // ¬рем€, за которое переменна€ измен€етс€ от 0 до 1 и обратно
    public bool isPaused = false;
    public TextMeshProUGUI hitText;
    public float CurrentPower;
    public float CurrentAngle;


    public Upgrader powerUpgrader;

    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    [Range(0,1)]
    public float t;

    private void Start()
    {
        t = 0;
        isPaused = false;
    }


    

    public void Da()
    {
        hitText.gameObject.SetActive(true);
    }


    public void GetForceByHit()
    {
        Da();

        

        if (t >= 0.901f)
        {
            print("big lower power");
            hitText.text = "AWFUL";
            CurrentAngle = 8f;
        }
        if (t < 0.901f && t >= 0.797f)
        {
            print("some lower power");
            hitText.text = "BAD";
            CurrentAngle = 15f;
        }

        if (t >= 0.672 && t < 0.797f)
        {
            CurrentAngle = 35f;
            hitText.text = "NOT BAD";
            print("idk");
        }

        if (t >= 0.563 && t < 0.672f)
        {
            CurrentAngle = 40f;
            hitText.text = "GOOD";
            print("wtf");
        }

        if (t >= 0.442f && t < 0.563f)
        {
            print("The best");
            hitText.text = "PERFECT";
            CurrentAngle = 45f;
        }

        if (t > 0.3f && t <= 0.441f)
        {
            print("some power shit");
            hitText.text = "GOOD";
            CurrentAngle = 55f;
        }

        if (t > 0.19f && t <= 0.3f)
        {
            print("middle power");
            hitText.text = "NOT BAD";
            CurrentAngle = 65f;
        }
        if (t >= 0.09f && t <= 0.19f)
        {
            CurrentAngle = 75f;
            print("some power");
            hitText.text = "BAD";
        }
        if (t >= 0 && t < 0.09f)
        {
            CurrentAngle = 80f;
            hitText.text = "AWFUL";
            
        }


        // если не попаду в этот диапазон, но значение будет такое которое задам сначала
    }

    public void ChangeActive(bool active)
    {
        MeterUi.SetActive(active);
        hitText.gameObject.SetActive(false);
    }
    


    private void Update()
    {
        CurrentPower = powerUpgrader.currentValue;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    isPaused = !isPaused; // ѕереключаем состо€ние паузы
        //}
        //GetForceByHit();

        // ≈сли не в паузе, обновл€ем значение переменной
        if (!isPaused)
        {
            t = Mathf.PingPong(Time.time / duration, 1f);
        }

        transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
        
    }

    private void OnDrawGizmos()
    {
        int number = 20;
        Vector3 preveousPoint = p0.position;

        for (int i = 0; i < number + 1; i++)
        {
            float parameter = (float)i / number;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(preveousPoint, point);
            preveousPoint = point;
        }
    }
}
