using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Meter;
    public PowerMeter powerMeter;
    public GunVisual gunVisual;
    Vector3 ballStartPosition;

    private void Start()
    {
        ballStartPosition = Ball.transform.position;
        print(ballStartPosition);
    }

    public void ResetSHIT()
    {
        AudioSystem.Instance.defaultButtons.PlayOneShot(AudioSystem.Instance.defaultButtons.clip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void LevelReset()
    {
        Meter.SetActive(true);
        powerMeter.isPaused = false;
        Ball.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Ball.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;

        Ball.transform.position = ballStartPosition;
        gunVisual.Clicked = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ResetSHIT();
        }
    }
}
