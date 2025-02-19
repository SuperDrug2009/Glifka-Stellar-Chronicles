using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChanger : MonoBehaviour
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void ChangeLayer(int number)
    {
        canvas.sortingOrder = number;
    }
}
