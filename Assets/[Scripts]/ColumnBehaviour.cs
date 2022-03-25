using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehaviour : MonoBehaviour
{
    public int ColumnNum;
    public static int SlotsInColumn = 7;
    public int EmptySlots = 7;

    [SerializeField] CandyManager candyManager;
    SpawnerBehaviour spawnerBehaviour;

    [SerializeField] bool canSpawn;

    void Start()
    {
        spawnerBehaviour = GetComponentInChildren<SpawnerBehaviour>();
    }

    void Update()
    {

        if (canSpawn && EmptySlots > 0)
        {
            if (Time.frameCount % 180 == 0 && candyManager.HasCandies())
            {
                spawnerBehaviour.SpawnCandy();
                EmptySlots--;
            }
        }

    }

}
