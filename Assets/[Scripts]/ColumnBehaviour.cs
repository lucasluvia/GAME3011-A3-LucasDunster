using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehaviour : MonoBehaviour
{
    public int ColumnNum;
    public static int SlotsInColumn = 7;
    public int EmptySlots = 7;

    CandyManager candyManager;
    SpawnerBehaviour spawnerBehaviour;


    void Start()
    {
        candyManager = GameObject.FindWithTag("GameController").GetComponent<CandyManager>();
        spawnerBehaviour = GetComponentInChildren<SpawnerBehaviour>();
    }

    void Update()
    {
        if (EmptySlots > 0)
        {
            if (Time.frameCount % 180 == 0 && candyManager.HasCandies())
            {
                spawnerBehaviour.SpawnCandy();
                EmptySlots--;
            }
        }

    }

}
