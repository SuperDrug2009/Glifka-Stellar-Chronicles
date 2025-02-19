using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject goDark;

    public IEnumerator LoadScene(int scene)
    {
        AudioSystem.Instance.defaultButtons.PlayOneShot(AudioSystem.Instance.defaultButtons.clip);
        goDark.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        DelayedSceneChange(scene);
    }

    public void GoChangeScene(int SCENE)
    {
        StartCoroutine(LoadScene(SCENE));
    }


    public void DelayedSceneChange(int index)
    {

        SceneManager.LoadScene(index);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }





    
}
