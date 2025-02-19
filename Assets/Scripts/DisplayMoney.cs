using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    private void Start()
    {
        RedrawDisplay();
    }

    private void Update()
    {
        _moneyText.text = Money.Instance.CurrentMoney.ToString("F0");
    }

    public void RedrawDisplay()
    {
        _moneyText.text = Money.Instance.CurrentMoney.ToString("F0");
    }
}
