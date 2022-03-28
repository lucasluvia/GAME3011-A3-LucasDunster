using System;
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

    CandyBehaviour temp = null;
    public CandyManager candyManager;

    public List<GameObject> SelectedCandies = new List<GameObject>();

    CandyBehaviour selectedTileB;
    int selectedTiles;


    float elapsed = 0f;
    void Update()
    {
        elapsed += Time.deltaTime;
        if (CheckIsFull())
        {
            elapsed = elapsed % 1f;
            CheckForMatches();
            if(!CheckIsFull())
            {
                ToggleMatchingPause(true);
            }
            else
            {
                ToggleMatchingPause(false);
            }
        }

        if(SelectedCandies.Count > 1)
        {
            SwapTiles(SelectedCandies[0], SelectedCandies[1]);

            SelectedCandies.Clear();
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
            obj.GetComponent<CandyBehaviour>().isClickable = !isPaused;
        }
    }

    public void CheckForMatches()
    {
        ToggleMatchingPause(true);

        CheckForVMatches();
        CheckForHMatches();

        ToggleMatchingPause(false);
    }

    public void CheckForVMatches()
    {
        CheckColumn(0);
        CheckColumn(1);
        CheckColumn(2);
        CheckColumn(3);
        CheckColumn(4);
        CheckColumn(5);
        CheckColumn(6);
    }

    public void CheckForHMatches()
    {
        CheckRow(0);
        CheckRow(1);
        CheckRow(2);
        CheckRow(3);
        CheckRow(4);
        CheckRow(5);
        CheckRow(6);
    }

    static int SortByCol(GameObject c1, GameObject c2)
    {
        return c1.GetComponent<CandyBehaviour>().ColRow.x.CompareTo(c2.GetComponent<CandyBehaviour>().ColRow.x);
    }

    private void CheckRow(int row)
    {
        int currentCountC = 0;

        List<GameObject> PossibleChecksC = new List<GameObject>(); 
        List<GameObject> CurrentRowObjects = new List<GameObject>();
        CandyType lastTypeC = CandyType.NONE;

        var objectsC = GameObject.FindGameObjectsWithTag("Candy");
        var objectCountC = objectsC.Length;

        // Sort the objects. By default row objects are unsorted

        foreach (var objC in objectsC)
        {
            if (objC.GetComponent<CandyBehaviour>().ColRow.y == row)
            {
                CurrentRowObjects.Add(objC);
            }
        }

        CurrentRowObjects.Sort(SortByCol);

        foreach (var objC in CurrentRowObjects)
        {
            
            if (objC.GetComponent<CandyBehaviour>().ColRow.y == row)
            {



                //Debug.Log("(" + objC.GetComponent<CandyBehaviour>().ColRow.x + "," + objC.GetComponent<CandyBehaviour>().ColRow.y + ")");
                //objC.GetComponent<CandyBehaviour>().markedForReturn = true;
                if (currentCountC >= 3 && lastTypeC != objC.GetComponent<CandyBehaviour>().type)
                {
                    MarkChecksForReturn(PossibleChecksC);
                }

                switch (objC.GetComponent<CandyBehaviour>().type)
                {
                    case CandyType.CANDY_RED:
                        if (lastTypeC != CandyType.CANDY_RED)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_RED;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_ORANGE:
                        if (lastTypeC != CandyType.CANDY_ORANGE)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_ORANGE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_YELLOW:
                        if (lastTypeC != CandyType.CANDY_YELLOW)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_YELLOW;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_GREEN:
                        if (lastTypeC != CandyType.CANDY_GREEN)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_GREEN;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_BLUE:
                        if (lastTypeC != CandyType.CANDY_BLUE)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_BLUE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_PURPLE:
                        if (lastTypeC != CandyType.CANDY_PURPLE)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_PURPLE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                }
            }
        }

        if (PossibleChecksC.Count > 2)
        {
            MarkChecksForReturn(PossibleChecksC);
        }
    }

    private void CheckColumn(int col)
    {
        int currentCountC = 0;

        List<GameObject> PossibleChecksC = new List<GameObject>();
        CandyType lastTypeC = CandyType.NONE;

        var objectsC = GameObject.FindGameObjectsWithTag("Candy");
        var objectCountC = objectsC.Length;
        foreach (var objC in objectsC)
        {
            if (objC.GetComponent<CandyBehaviour>().ColRow.x == col)
            {
                //objC.GetComponent<CandyBehaviour>().markedForReturn = true;
                if (currentCountC >= 3 && lastTypeC != objC.GetComponent<CandyBehaviour>().type)
                {
                    MarkChecksForReturn(PossibleChecksC);
                }

                switch (objC.GetComponent<CandyBehaviour>().type)
                {
                    case CandyType.CANDY_RED:
                        if (lastTypeC != CandyType.CANDY_RED)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_RED;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_ORANGE:
                        if (lastTypeC != CandyType.CANDY_ORANGE)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_ORANGE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_YELLOW:
                        if (lastTypeC != CandyType.CANDY_YELLOW)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_YELLOW;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_GREEN:
                        if (lastTypeC != CandyType.CANDY_GREEN)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_GREEN;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_BLUE:
                        if (lastTypeC != CandyType.CANDY_BLUE)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_BLUE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_PURPLE:
                        if (lastTypeC != CandyType.CANDY_PURPLE)
                        {
                            currentCountC = 1;
                            lastTypeC = CandyType.CANDY_PURPLE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC++;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                }
            }
        }

        if (PossibleChecksC.Count > 2)
        {
            ToggleMatchingPause(false);
            MarkChecksForReturn(PossibleChecksC);
        }
    }

    private void MarkChecksForReturn(List<GameObject> checksToReturn)
    {
        for (int i = 0; i < checksToReturn.Count; i++)
        {
            //checksToReturn[i].GetComponent<CandyBehaviour>().markedForReturn = true;
            var colToReduce = checksToReturn[i].GetComponent<CandyBehaviour>().ColRow.x;

            var objectsC = GameObject.FindGameObjectsWithTag("Column");
            var objectCountC = objectsC.Length;
            foreach (var objC in objectsC)
            {
                if(objC.GetComponent<ColumnBehaviour>().ColumnNum == colToReduce)
                {
                    objC.GetComponent<ColumnBehaviour>().EmptySlots++;
                }
            }
            candyManager.ReturnCandy(checksToReturn[i]);
        }
    }

    public void SelectTile(GameObject tile)
    {
        SelectedCandies.Add(tile);
    }

    public void SwapTiles(GameObject c1, GameObject c2)
    {
        var c1_behaviour = c1.GetComponent<CandyBehaviour>();
        var c2_behaviour = c2.GetComponent<CandyBehaviour>();

        if ((c1_behaviour.type == CandyType.BOX || c1_behaviour.type == CandyType.NONE) ||  // make sure c1 is movable and has a type assigned
            (c2_behaviour.type == CandyType.BOX || c2_behaviour.type == CandyType.NONE) ||  // make sure c2 is movable and has a type assigned
            (c1_behaviour.type == c2_behaviour.type))                                       // make sure c1 and c2 are unique to one another
        {
            return;
        }

        CandyType tempType = c1_behaviour.type;
        bool tempIsBomb = c1_behaviour.isBomb;

        //Debug.Log("Temp (" + temp.type + ")");
        Debug.Log("Before (" + c1_behaviour.type + "," + c2_behaviour.type + ")");

        //set new type
        c1_behaviour.type = c2_behaviour.type;
        c2_behaviour.type = tempType;

        //Debug.Log("Temp (" + temp.type + ")");
        Debug.Log("After (" + c1_behaviour.type + "," + c2_behaviour.type + ")");

        //set isBomb
        //temp.isBomb = c1_behaviour.isBomb;
        c1_behaviour.isBomb = c2_behaviour.isBomb;
        c2_behaviour.isBomb = tempIsBomb;

        //reset temp
        tempType = CandyType.NONE;
        tempIsBomb = false;

        //trigger swap for tiles
        c1_behaviour.swapTrigger = true;
        c2_behaviour.swapTrigger = true;



    }

    public bool CheckIsFull()
    {
        var objectsC = GameObject.FindGameObjectsWithTag("Candy");
        var objectCountC = objectsC.Length;
        if (objectCountC == 49)
        {
            return (objectsC[48].transform.position.y < 900);
        }
        else
        {
            return false;
        }


    }


}
