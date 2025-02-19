using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private DisplayMoney _displayMoney;
    public const string moneyKey = "MyMoney";
    public static Money Instance;    
    public float CurrentMoney;


    public event Action onMoneyChanged;

    private void OnDisable()
    {
        onMoneyChanged -= _displayMoney.RedrawDisplay;
    }

    private void OnEnable()
    {
        onMoneyChanged += _displayMoney.RedrawDisplay;
    }

    private void Awake()
    {
        if (!Instance)   
            Instance = this;
        else      
            Destroy(gameObject);      
    }

    private void Start()
    {
        _displayMoney = FindObjectOfType<DisplayMoney>();
        Instance.CurrentMoney = PlayerPrefs.GetFloat(moneyKey);
    }

    private void Update()
    {
        Instance.CurrentMoney = PlayerPrefs.GetFloat(moneyKey);

        if (Input.GetKeyDown(KeyCode.M))
        {
            AddMoney(50000);
        }
    }

    public void SpendMoney(float price)
    {
        if (price > 0)    
            if (CurrentMoney >= price)
            {
                CurrentMoney = CurrentMoney - price;
                onMoneyChanged?.Invoke();
                SaveMoney();
            }
                       
            else         
                return;                      
    }


    public void AddMoney(float count)
    {
        if (count > 0)
        {
            CurrentMoney = CurrentMoney + count;
            onMoneyChanged?.Invoke();
            SaveMoney();
        }      
        else
            return;  
        
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetFloat(moneyKey, Instance.CurrentMoney);
        PlayerPrefs.Save();
    }
}
