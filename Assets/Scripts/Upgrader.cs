using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    public TextMeshProUGUI costUItext;
    

    public float cost;
    public float willAddToValue;
    public float currentValue;

    public string CostKEY;
    public string CurrentValueKEY;

    public float firstCost;
    public float firstValue;


    private void Update()
    {
        cost = PlayerPrefs.GetFloat(CostKEY, firstCost);
        currentValue = PlayerPrefs.GetFloat(CurrentValueKEY, firstValue);

        costUItext.text = cost.ToString("F0");

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }


    public void UpgradeCoinPerMeter()
    {
        if (Money.Instance.CurrentMoney >= cost)
        {
            Money.Instance.SpendMoney(cost);
            AudioSystem.Instance.MARKETCLICKS.PlayOneShot(AudioSystem.Instance.MARKETCLICKS.clip);

            cost = cost + 20;
            PlayerPrefs.SetFloat(CostKEY, cost);
            currentValue = currentValue + 1;
            PlayerPrefs.SetFloat (CurrentValueKEY, currentValue);
        }
    }

    


    public void UpgradePower()
    {
        if (Money.Instance.CurrentMoney >= cost)
        {
            Money.Instance.SpendMoney(cost);
            AudioSystem.Instance.MARKETCLICKS.PlayOneShot(AudioSystem.Instance.MARKETCLICKS.clip);

            cost = cost + 50;
            PlayerPrefs.SetFloat(CostKEY, cost);
            currentValue = currentValue + 50;
            PlayerPrefs.SetFloat(CurrentValueKEY, currentValue);
        }
    }

    public void UpgradeBounce()
    {
        if (Money.Instance.CurrentMoney >= cost)
        {
            Money.Instance.SpendMoney(cost);
            AudioSystem.Instance.MARKETCLICKS.PlayOneShot(AudioSystem.Instance.MARKETCLICKS.clip);

            cost = cost + 50;
            PlayerPrefs.SetFloat(CostKEY, cost);
            currentValue = currentValue + 0.02f;
            PlayerPrefs.SetFloat(CurrentValueKEY, currentValue);
        }
    }
}
