using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Candy Sprites")]
    public Sprite RedCandy;
    public Sprite OrangeCandy;
    public Sprite YellowCandy;
    public Sprite GreenCandy;
    public Sprite BlueCandy;
    public Sprite PurpleCandy;

    [Header("Bomb Sprites")]
    public Sprite RedBomb;
    public Sprite OrangeBomb;
    public Sprite YellowBomb;
    public Sprite GreenBomb;
    public Sprite BlueBomb;
    public Sprite PurpleBomb;

    CandyBehaviour temp;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            CheckForMatches();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            ToggleSpawningPause(false);
        }
    }



    public void ToggleSpawningPause(bool isPaused)
    {
        var objects = GameObject.FindGameObjectsWithTag("Column");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            obj.GetComponent<ColumnBehaviour>().isSpawnPaused = isPaused;
        }
    }

    public void ToggleMatchingPause(bool isPaused)
    {
        var objects = GameObject.FindGameObjectsWithTag("Candy");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            obj.GetComponent<Button>().interactable = !isPaused;
        }
    }

    public void CheckForMatches()
    {
        ToggleMatchingPause(true);
        ToggleSpawningPause(true);

        CheckColumn(0);
        CheckColumn(1);
        CheckColumn(2);
        CheckColumn(3);
        CheckColumn(4);
        CheckColumn(5);
        CheckColumn(6);

    }

    private void CheckColumn(int col)
    {
        int R_inCol;
        int O_inCol;
        int Y_inCol;
        int G_inCol;
        int B_inCol;
        int P_inCol;

        bool checkRed;
        bool checkOrange;
        bool checkYellow;
        bool checkGreen;
        bool checkBlue;
        bool checkPurple;

        int currentCount = 0;

        List<GameObject> PossibleChecks = new List<GameObject>();
        CandyType lastType = CandyType.NONE;

        var objects = GameObject.FindGameObjectsWithTag("Candy");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (obj.GetComponent<CandyBehaviour>().ColRow.x == col)
            {

                if(currentCount >= 3 && lastType != obj.GetComponent<CandyBehaviour>().type)
                {
                    MarkChecksForReturn(PossibleChecks);
                }

                switch (obj.GetComponent<CandyBehaviour>().type)
                {
                    case CandyType.CANDY_RED:
                        if (lastType != CandyType.CANDY_RED)
                        {
                            currentCount = 1;
                            lastType = CandyType.CANDY_RED;
                            if (PossibleChecks.Count > 0)
                                PossibleChecks.Clear();
                        }
                        else
                        {
                            currentCount++;
                        }
                        PossibleChecks.Add(obj);
                        break;
                    case CandyType.CANDY_ORANGE:
                        if (lastType != CandyType.CANDY_ORANGE)
                        {
                            currentCount = 1;
                            lastType = CandyType.CANDY_ORANGE;
                            if (PossibleChecks.Count > 0)
                            PossibleChecks.Clear();
                        }
                        else
                        {
                            currentCount++;
                        }
                        PossibleChecks.Add(obj);
                        break;
                    case CandyType.CANDY_YELLOW:
                        if (lastType != CandyType.CANDY_YELLOW)
                        {
                            currentCount = 1;
                            lastType = CandyType.CANDY_YELLOW;
                            if (PossibleChecks.Count > 0)
                            PossibleChecks.Clear();
                        }
                        else
                        {
                            currentCount++;
                        }
                        PossibleChecks.Add(obj);
                        break;
                    case CandyType.CANDY_GREEN:
                        if (lastType != CandyType.CANDY_GREEN)
                        {
                            currentCount = 1;
                            lastType = CandyType.CANDY_GREEN;
                            if (PossibleChecks.Count > 0)
                            PossibleChecks.Clear();
                        }
                        else
                        {
                            currentCount++;
                        }
                        PossibleChecks.Add(obj);
                        break;
                    case CandyType.CANDY_BLUE:
                        if (lastType != CandyType.CANDY_BLUE)
                        {
                            currentCount = 1;
                            lastType = CandyType.CANDY_BLUE;
                            if (PossibleChecks.Count > 0)
                                PossibleChecks.Clear();
                        }
                        else
                        {
                            currentCount++;
                        }
                        PossibleChecks.Add(obj);
                        break;
                    case CandyType.CANDY_PURPLE:
                        if (lastType != CandyType.CANDY_PURPLE)
                        {
                            currentCount = 1;
                            lastType = CandyType.CANDY_PURPLE;
                            if (PossibleChecks.Count > 0)
                            PossibleChecks.Clear();
                        }
                        else
                        {
                            currentCount++;
                        }
                        PossibleChecks.Add(obj);
                        break;
                }
            }
        }

        if (PossibleChecks.Count > 2)
        {
            MarkChecksForReturn(PossibleChecks);
        }
    }

    private void MarkChecksForReturn(List<GameObject> checksToReturn)
    {
        for (int i = 0; i < checksToReturn.Count; i++)
        {
            checksToReturn[i].GetComponent<CandyBehaviour>().markedForReturn = true;
        }
    }

    public void SwapTiles(CandyBehaviour c1, CandyBehaviour c2)
    {
        if ((c1.type == CandyType.BOX || c1.type == CandyType.NONE) ||  // make sure c1 is movable and has a type assigned
            (c2.type == CandyType.BOX || c2.type == CandyType.NONE) ||  // make sure c2 is movable and has a type assigned
            (c1.type == c2.type))                                       // make sure c1 and c2 are unique to one another
        {
            return;
        }

        //set new type
        temp.type = c1.type;
        c1.type = c2.type;
        c2.type = c1.type;

        //set isBomb
        temp.isBomb = c1.isBomb;
        c1.isBomb = c2.isBomb;
        c2.isBomb = c1.isBomb;

        //reset temp
        temp.type = CandyType.NONE;
        temp.isBomb = false;

        //trigger swap for tiles
        c1.swapTrigger = true;
        c2.swapTrigger = true;

    }




}
