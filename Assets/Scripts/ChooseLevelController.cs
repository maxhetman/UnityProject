using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChooseLevelController : MonoBehaviour
{
    public static ChooseLevelController Instance;
    
    private Vector3 _startPosition;
    private AudioSource bgMusic;
    void Awake()
    {
        Instance = this;
        _startPosition = RabbitController.Instance.transform.position;
        bgMusic = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (SoundManager.isMusicOn())
        {
            bgMusic.Play();
        }
    }

    public void ResetRabbit()
    {
        RabbitController.Instance.transform.position = _startPosition;
    }
}
