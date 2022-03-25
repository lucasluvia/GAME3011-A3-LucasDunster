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

    float elapsed = 0f;
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            if (EmptySlots > 0 && candyManager.HasCandies())
                SpawnNewCandy();
        }

    }

    void SpawnNewCandy()
    {
        spawnerBehaviour.SpawnCandy(ColumnNum);
        EmptySlots--;
    }

}
