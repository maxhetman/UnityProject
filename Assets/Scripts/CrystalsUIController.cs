using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsUIController : MonoBehaviour
{

    public UI2DSprite GreenCrystalPlaceholder;
    public UI2DSprite BlueCrystalPlaceholder;
    public UI2DSprite RedCrystalPlaceholder;

    public Sprite GreenCrystalSprite;
    public Sprite BlueCrystalSprite;
    public Sprite RedCrystalSprite;

    public enum CrystalType
    {
        RED, BLUE, GREEN
    }

    void Start()
    {
        LevelController.Instance.OnCrystalPicked += OnCrystalCollected;
    }

    public void OnCrystalCollected(CrystalType type)
    {
        switch (type)
        {
            case CrystalType.BLUE:
                BlueCrystalPlaceholder.sprite2D = BlueCrystalSprite;
                return;
            case CrystalType.GREEN:
                GreenCrystalPlaceholder.sprite2D = GreenCrystalSprite;
                return;
            case CrystalType.RED:
                RedCrystalPlaceholder.sprite2D = RedCrystalSprite;
                return;
        }
        
    }
}
