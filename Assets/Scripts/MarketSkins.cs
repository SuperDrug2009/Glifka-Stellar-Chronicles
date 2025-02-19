using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSkins : MonoBehaviour
{
    public GameObject[] uiElements;


    private string SelectedElementKey = "SelectedElementIndex";


    int savedIndex;



    void Start()
    {
        savedIndex = PlayerPrefs.GetInt(SelectedElementKey, 0);
        SetActiveElement(savedIndex);

    }

    public void SetActiveElement(int index)
    {

        if (index < 0 || index >= uiElements.Length)
        {
            Debug.LogWarning("Индекс вне диапазона!");
            return;
        }

        foreach (GameObject element in uiElements)
        {
            element.SetActive(false);
        }


        uiElements[index].SetActive(true);


        PlayerPrefs.SetInt(SelectedElementKey, index);
        PlayerPrefs.Save();
    }




    public void OnElementClicked(int index)
    {
        SetActiveElement(index);
    }

}
