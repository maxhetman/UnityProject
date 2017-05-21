using UnityEngine;

public class LevelController : MonoBehaviour {

    public static LevelController Instance;
    public Transform StartingTransform;

    void Awake()
    {
        Instance = this;
    }

    
    public void OnRabitDeath(RabbitController rabit)
    {
        rabit.transform.position = StartingTransform.position;
    }

}
