using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    CandyManager candyManager;


    public CandyType nextType;
    public bool isNextBomb = false;
    public bool isNextBox = false;

    void Start()
    {
        candyManager = GameObject.FindWithTag("GameController").GetComponent<CandyManager>();
    }

    public void SpawnCandy()
    {
        SetNextColour(Random.Range(0, 5));
        candyManager.GetCandy(transform.position, nextType, isNextBomb, isNextBox);
    }

    void SetNextColour(int colourValue)
    {
        if (colourValue == 0)
        {
            nextType = CandyType.CANDY_RED;
        }
        else if (colourValue == 1)
        {
            nextType = CandyType.CANDY_ORANGE;
        }
        else if (colourValue == 2)
        {
            nextType = CandyType.CANDY_YELLOW;
        }
        else if (colourValue == 3)
        {
            nextType = CandyType.CANDY_GREEN;
        }
        else if (colourValue == 4)
        {
            nextType = CandyType.CANDY_BLUE;
        }
        else if (colourValue == 5)
        {
            nextType = CandyType.CANDY_PURPLE;
        }
    }

}
