using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public const string RecordKey = "recordKey";
    
    public Image bar;
    public TextMeshProUGUI recoredText;
    public TextMeshProUGUI currentMeters;
    public Transform ball;
    public Upgrader MoneyUpgrader;
    public GameObject WinPanel;
    public LayerChanger changer;

    public float CoinsPerMeter;
    public float EndLevelMoney;
    public float distanceInMeters;

    public TextMeshProUGUI _recordUI;
    public TextMeshProUGUI _moneyUI;

    public GameObject LosePanel;

    public TextMeshProUGUI _TryNowCollectedCoins;
    public TextMeshProUGUI _TryNowDistanceText;
    public TextMeshProUGUI _WinPanelRecordText;


    public float recordSaved;


    public void FirstGameState()
    {
        recoredText.text = 0.ToString();
    }


    private Vector2 startPosition; // Начальная позиция мяча
    private float distanceTraveled; // Пройденное расстояние в метрах

    void Start()
    {
        // Сохраняем начальную позицию мяча
        startPosition = ball.transform.position;
        print(startPosition);
    }

    public float factor = 0.2f;

    public void CollectMoneyAndSetRecord()
    {
        Money.Instance.AddMoney(EndLevelMoney);
        PlayerPrefs.SetFloat(RecordKey, distanceInMeters);

        print("СУКА");
    }

    public void CollectMoneyByLose()
    {
        Money.Instance.AddMoney(EndLevelMoney);
    }

    public void Record()
    {

    }

    int levelWinInt = 0;
    int levelLoseInt = 0;

    void Update()
    {
        CoinsPerMeter = MoneyUpgrader.currentValue; // Сколько монет за метр
        distanceTraveled = Vector2.Distance(startPosition, ball.transform.position); //Считаем метры
        distanceInMeters = distanceTraveled * factor; // метры уменьшаем просто похуй




        recordSaved = PlayerPrefs.GetFloat(RecordKey, 10);

        recoredText.text = recordSaved.ToString("F0");

        //Debug.Log("Пройденное расстояние: " + distanceInMeters + " метров");


        currentMeters.text = distanceInMeters.ToString("F0");

        //recoredText.text = currentMeters.text.ToString();




         

        // Это победа

        if (ball.gameObject.GetComponent<Rigidbody2D>().velocity.x <= 0 && distanceInMeters > 1f && distanceInMeters > recordSaved)
        {
            EndLevelMoney = distanceInMeters * MoneyUpgrader.currentValue;
            _moneyUI.text = EndLevelMoney.ToString("F0");

            _WinPanelRecordText.text = distanceInMeters.ToString("F0");
            //звук победы бы добавить
            levelWinInt++;

            if (levelWinInt == 1)
            {
                AudioSystem.Instance.LevelWinMusic.PlayOneShot(AudioSystem.Instance.LevelWinMusic.clip);
            }

            
            changer.ChangeLayer(100);
            WinPanel.SetActive(true);
        }

        if (ball.gameObject.GetComponent<Rigidbody2D>().velocity.x <= 0 && distanceInMeters > 1f && distanceInMeters < recordSaved)
        {
            EndLevelMoney = distanceInMeters * MoneyUpgrader.currentValue;
            _TryNowCollectedCoins.text = EndLevelMoney.ToString("F0");
            _TryNowDistanceText.text = distanceInMeters.ToString("F0");



            //звук lose бы добавить

            levelLoseInt++;

            if (levelLoseInt == 1)
            {
                AudioSystem.Instance.levelLose.PlayOneShot(AudioSystem.Instance.levelLose.clip);
            }


            changer.ChangeLayer(100);
            LosePanel.SetActive(true);
        }
    }


    public Image image; // Ссылка на компонент Image
    public float fillSpeed = 2f; // Скорость заполнения

    ////////void Start()
    ////////{
    ////////    // Запускаем корутину для заполнения
    ////////    StartCoroutine(FillImageCoroutine());
    ////////}

    public IEnumerator FillImageCoroutine()
    {
        // Устанавливаем начальное значение fillAmount
        image.fillAmount = 0;

        // Постепенно увеличиваем fillAmount до 1
        while (image.fillAmount < 1f)
        {
            image.fillAmount += fillSpeed * Time.deltaTime; // Увеличиваем значение на fillSpeed * Time.deltaTime
            yield return null; // Ждем следующий кадр
        }

        // Убедитесь, что значение fillAmount точно 1 после завершения
        
    }


}
