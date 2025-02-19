using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsInteractive : MonoBehaviour
{

    [SerializeField] public GunVisual Gun;
    [SerializeField] public Button[] _buttons;

    

    public void ChangeState(bool active)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = active;
        }
    }

    private void Update()
    {
        if (!Gun.Clicked)
        {
            ChangeState(true);
        }
        else
        {
            ChangeState(false);
        }
    }
}
