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


    private Vector2 startPosition; // ��������� ������� ����
    private float distanceTraveled; // ���������� ���������� � ������

    void Start()
    {
        // ��������� ��������� ������� ����
        startPosition = ball.transform.position;
        print(startPosition);
    }

    public float factor = 0.2f;

    public void CollectMoneyAndSetRecord()
    {
        Money.Instance.AddMoney(EndLevelMoney);
        PlayerPrefs.SetFloat(RecordKey, distanceInMeters);

        print("����");
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
        CoinsPerMeter = MoneyUpgrader.currentValue; // ������� ����� �� ����
        distanceTraveled = Vector2.Distance(startPosition, ball.transform.position); //������� �����
        distanceInMeters = distanceTraveled * factor; // ����� ��������� ������ �����




        recordSaved = PlayerPrefs.GetFloat(RecordKey, 10);

        recoredText.text = recordSaved.ToString("F0");

        //Debug.Log("���������� ����������: " + distanceInMeters + " ������");


        currentMeters.text = distanceInMeters.ToString("F0");

        //recoredText.text = currentMeters.text.ToString();




         

        // ��� ������

        if (ball.gameObject.GetComponent<Rigidbody2D>().velocity.x <= 0 && distanceInMeters > 1f && distanceInMeters > recordSaved)
        {
            EndLevelMoney = distanceInMeters * MoneyUpgrader.currentValue;
            _moneyUI.text = EndLevelMoney.ToString("F0");

            _WinPanelRecordText.text = distanceInMeters.ToString("F0");
            //���� ������ �� ��������
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



            //���� lose �� ��������

            levelLoseInt++;

            if (levelLoseInt == 1)
            {
                AudioSystem.Instance.levelLose.PlayOneShot(AudioSystem.Instance.levelLose.clip);
            }


            changer.ChangeLayer(100);
            LosePanel.SetActive(true);
        }
    }


    public Image image; // ������ �� ��������� Image
    public float fillSpeed = 2f; // �������� ����������

    ////////void Start()
    ////////{
    ////////    // ��������� �������� ��� ����������
    ////////    StartCoroutine(FillImageCoroutine());
    ////////}

    public IEnumerator FillImageCoroutine()
    {
        // ������������� ��������� �������� fillAmount
        image.fillAmount = 0;

        // ���������� ����������� fillAmount �� 1
        while (image.fillAmount < 1f)
        {
            image.fillAmount += fillSpeed * Time.deltaTime; // ����������� �������� �� fillSpeed * Time.deltaTime
            yield return null; // ���� ��������� ����
        }

        // ���������, ��� �������� fillAmount ����� 1 ����� ����������
        
    }


}
