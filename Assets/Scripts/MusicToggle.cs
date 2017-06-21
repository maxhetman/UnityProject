using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : MonoBehaviour
{

    public static MusicToggle Instance;

    public GameObject MusicToggler;

    void Awake()
    {
        Debug.Log("HERE");
        Instance = this;
    }

    public void SwitchMusic()
    {
        if (SoundManager.Instance.isMusicOn())
        {
            SoundManager.Instance.setMusicOn(false);
            ToggleMusic(false);
        }
        else
        {
            SoundManager.Instance.setMusicOn(true);
            ToggleMusic(true);
        }
    }

    private void ToggleMusic(bool state)
    {
        IMusicToggler toggler = MusicToggler.GetComponent<IMusicToggler>();
        if (toggler != null)
        {
            Debug.Log("HERE");
            toggler.SetMusic(state);
        }
    }


}
