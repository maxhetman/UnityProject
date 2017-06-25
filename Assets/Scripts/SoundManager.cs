using UnityEngine;

public static class SoundManager
{
    static bool is_sound_on = true;

    static bool is_music_on = true;

    public static bool isSoundOn()
    {
        return is_sound_on;
    }

    public static bool isMusicOn()
    {
        return is_music_on;
    }

    public static void setSoundOn(bool val)
    {
        is_sound_on = val;
        PlayerPrefs.SetInt("sound", is_sound_on ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static void setMusicOn(bool val)
    {

        is_music_on = val;
        PlayerPrefs.SetInt("music", is_music_on ? 1 : 0);
        PlayerPrefs.Save();
    }

    static SoundManager()
    {
        is_sound_on = PlayerPrefs.GetInt("sound", 1) == 1;
        is_music_on = PlayerPrefs.GetInt("music", 1) == 1;
    }
}