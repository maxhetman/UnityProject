using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUIController : MonoBehaviour
{

    [SerializeField] private List<UI2DSprite> _lifeIcons;
    [SerializeField] private Sprite _lifeUsedSprite;

    private int _currenLifeIndex;

    void Start()
    {
        LevelController.Instance.OnLifeLost += OnLifeLost;
        _currenLifeIndex = _lifeIcons.Count - 1;
    }



    private void OnLifeLost()
    {
        if (_currenLifeIndex < 0)
        {
            Debug.Log("CURRENT LIFE INDEX < 0 !");
            return;
        }
        _lifeIcons[_currenLifeIndex].sprite2D = _lifeUsedSprite;
        _currenLifeIndex--;
    }
}
