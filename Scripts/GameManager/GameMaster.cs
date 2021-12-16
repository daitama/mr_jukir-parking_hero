using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    [SerializeField]
    private Player player;

    private bool isIncremented = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        IncreasePlayerSpeed();
    }

    void IncreasePlayerSpeed()
    {
        if (!isIncremented)
        {
            if (UITextManager.instance.score % 3 == 0 && UITextManager.instance.score != 0)
            {
                if(player.GetSpeed() < 25)
                {
                    player.IncreaseSpeed(1f);
                    isIncremented = true;
                }
            }
        }

        if(UITextManager.instance.score % 3 != 0)
        {
            isIncremented = false;
        }

    }
}
