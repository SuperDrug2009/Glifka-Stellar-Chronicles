using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] public AudioSource musicAudioSource; // +
    [SerializeField] public AudioSource MARKETCLICKS; // +
    
    [SerializeField] public AudioSource HITBALLSOUNS;
    [SerializeField] public AudioSource settingsButtonClick; // +
    [SerializeField] public AudioSource defaultButtons; // +
    [SerializeField] public AudioSource levelLose; // +
    [SerializeField] public AudioSource LevelWinMusic;// +

    public bool IsMutedAudios;
    public bool isMutedMusic;

    public static AudioSystem Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public void MuteAudios()
    {
        MARKETCLICKS.mute = true;
        LevelWinMusic.mute = true;
        HITBALLSOUNS.mute = true;
        settingsButtonClick.mute = true;
        defaultButtons.mute = true;
        levelLose.mute = true;
        IsMutedAudios = true;
    }

    public void ChangeAudios()
    {
        MARKETCLICKS.mute = !MARKETCLICKS.mute;
        LevelWinMusic.mute = !LevelWinMusic.mute;
        HITBALLSOUNS.mute = !HITBALLSOUNS.mute;
        settingsButtonClick.mute = !settingsButtonClick.mute;
        defaultButtons.mute = !defaultButtons.mute;
        levelLose.mute = !levelLose.mute;
    }




    public void MusicChange()
    {
        musicAudioSource.mute = !musicAudioSource.mute;
        isMutedMusic = true;
    }

    
}
