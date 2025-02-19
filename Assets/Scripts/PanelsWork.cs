using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsWork : MonoBehaviour
{
    private float posXFAR = -7818F;
    private float posYFAR = 5037F;

    private float posX = 0f; // Новое значение по оси X
    private float posY = 0f; // Новое значение по оси Y

    [SerializeField] RectTransform panelImprove;

    public void ChangeImprovePanelPosition()
    {
        AudioSystem.Instance.defaultButtons.PlayOneShot(AudioSystem.Instance.defaultButtons.clip);
        panelImprove.anchoredPosition = new Vector2(posX, posY);
    }

    public void ChangeImprovePanelPositionClose()
    {
        AudioSystem.Instance.defaultButtons.PlayOneShot(AudioSystem.Instance.defaultButtons.clip);
        panelImprove.anchoredPosition = new Vector2(posXFAR, posYFAR);
    }


    [SerializeField] GameObject panel;
    public void ChangePanelState(bool isActive)
    {
        AudioSystem.Instance.defaultButtons.PlayOneShot(AudioSystem.Instance.defaultButtons.clip);
        panel.SetActive(isActive);
    }
}
