using UnityEngine;

public class SoundManager
{
    bool is_sound_on = true;

    private bool is_music_on = true;

    public bool isSoundOn()
    {
        return this.is_sound_on;
    }

    public bool isMusicOn()
    {
        return this.is_music_on;
    }

    public void setSoundOn(bool val)
    {
        this.is_sound_on = val;
        PlayerPrefs.SetInt("sound", this.is_sound_on ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void setMusicOn(bool val)
    {
        Debug.Log("HERE BRO");
        this.is_music_on = val;
        PlayerPrefs.SetInt("music", this.is_music_on ? 1 : 0);
        PlayerPrefs.Save();
    }

    public SoundManager()
    {
        is_sound_on = PlayerPrefs.GetInt("sound", 1) == 1;
        is_sound_on = PlayerPrefs.GetInt("music", 1) == 1;
    }

    public static SoundManager Instance = new SoundManager();
}