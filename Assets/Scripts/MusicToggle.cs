using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIButton))]
public class MusicToggle : MonoBehaviour
{

    public static MusicToggle Instance;

    public GameObject MusicToggler;

    private UIButton _button;

    [SerializeField]
    private Sprite _musicOnSprite;
    [SerializeField]
    private Sprite _musicOffSprite;


    void Awake()
    {
        Instance = this;
        _button = GetComponent<UIButton>();
        _button.normalSprite2D = SoundManager.isMusicOn() ? _musicOnSprite : _musicOffSprite;

    }

    public void SwitchMusic()
    {
        if (SoundManager.isMusicOn())
        {
            SoundManager.setMusicOn(false);
            ToggleMusic(false);
            _button.normalSprite2D = _musicOffSprite;
            Debug.Log("TURN THIS SHIT OFF");
        }
        else
        {
            SoundManager.setMusicOn(true);
            ToggleMusic(true);
           _button.normalSprite2D = _musicOnSprite;
        }
    }

    private void ToggleMusic(bool state)
    {
        IMusicToggler toggler = MusicToggler.GetComponent<IMusicToggler>();
        if (toggler != null)
        {
            toggler.SetMusic(state);
        }
    }


}
