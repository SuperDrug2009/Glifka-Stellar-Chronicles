using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketItemState : MonoBehaviour
{
    public int Locked = 0;
    public int Unlocked = 1;
    public int State;

    public string PlayerPrefsKey;
    public int Price;
    public int index;
    public int SkinID;
    [SerializeField] public GameObject Lock;
    [SerializeField] public GameObject Lock2;


    [SerializeField] public TextMeshProUGUI UIprice;
    [SerializeField] public TextMeshProUGUI textToChange;
    [SerializeField] public MarketSkins market;
    [SerializeField] public Button ShopItemButton;


    private void Start()
    {
        if (transform.CompareTag("startSkin"))
        {
            PlayerPrefs.SetInt(PlayerPrefsKey, Unlocked);

            State = PlayerPrefs.GetInt(PlayerPrefsKey);
        }
        UIprice.text = Price.ToString();
        State = PlayerPrefs.GetInt(PlayerPrefsKey);
        ChekState();
    }

    public void ChekState()
    {
        if (State == Locked)
        {
            Lock.SetActive(true);
            Lock2.SetActive(true);
            ShopItemButton.interactable = false;

        }
        if (State == Unlocked)
        {
            Lock.SetActive(false);
            Lock2.SetActive(false);
            ShopItemButton.interactable = true;
        }
    }

    public void Buy()
    {
        if (State == Locked && Money.Instance.CurrentMoney >= Price)
        {
            Money.Instance.SpendMoney(Price);
            PlayerPrefs.SetInt(PlayerPrefsKey, Unlocked);
            print(State);
            State = PlayerPrefs.GetInt(PlayerPrefsKey);
            ChekState();
            AudioSystem.Instance.MARKETCLICKS.PlayOneShot(AudioSystem.Instance.MARKETCLICKS.clip);
            Money.Instance.SaveMoney();
        }
        if (!Lock.activeSelf)
        {
            market.OnElementClicked(index);
            PlayerPrefs.SetInt("skinID", SkinID);
            AudioSystem.Instance.MARKETCLICKS.PlayOneShot(AudioSystem.Instance.MARKETCLICKS.clip);
            print("уже куплено");
            return;
        }
    }


    private void Update()
    {
        if (transform.CompareTag("startSkin"))
        {
            PlayerPrefs.SetInt(PlayerPrefsKey, Unlocked);
            print(State);
            State = PlayerPrefs.GetInt(PlayerPrefsKey);
            State = 1;
        }

        ChekState();
    }


}

