using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour, IMusicToggler
{

    public AudioSource bgMusic;

    public void StartChooseLevelScene()
    {
        SceneManager.LoadScene("ChooseLevelScene");
    }

    void OnEnable()
    {
        if (SoundManager.Instance.isMusicOn())
        {
            SetMusic(true);
        }
    }

    public void SetMusic(bool state)
    {
        if (state)
        {
            bgMusic.Play();
        }
        else
        {
            bgMusic.Stop();
        }
    }
}
