using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideSettings : MonoBehaviour
{
    public RectTransform RectTransform;
    public RectTransform Rect2;

    public int MyProperty { get; private set; }

    private int myVar;



   





    public void ChangeRect()
    {
        Rect2.position = new Vector3(6666f, 1484f);
        RectTransform.position = new Vector3(5000f, -5000f);
        
    }
}
