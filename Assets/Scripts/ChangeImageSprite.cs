using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageSprite : MonoBehaviour
{
    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off;
    [SerializeField] private Image _image;


    public void ChangeSoundAudioSytem()
    {
        AudioSystem.Instance.settingsButtonClick.PlayOneShot(AudioSystem.Instance.settingsButtonClick.clip);
        AudioSystem.Instance.MusicChange();

    }

    public void ChangeEffects()
    {
        AudioSystem.Instance.settingsButtonClick.PlayOneShot(AudioSystem.Instance.settingsButtonClick.clip);
        AudioSystem.Instance.ChangeAudios();
    }

    private void Start()
    {
        if (AudioSystem.Instance.musicAudioSource.mute == true && transform.CompareTag("Music"))
        {
            _image.sprite = _off;
        }

        if (AudioSystem.Instance.settingsButtonClick.mute == true && transform.CompareTag("Settings"))
        {
            _image.sprite = _off;
        }
    }


    public void ChangeImage()
    {
        switch (_image.sprite)
        {
            case var s when s == _off:
                _image.sprite = _on;

                break;

            case var z when z == _on:
                _image.sprite = _off;


                break;
        }

    }
}
