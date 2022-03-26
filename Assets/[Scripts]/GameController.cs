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
    public CandyManager candyManager;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            CheckForVMatches();
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            //CheckForHMatches();
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

    public void CheckForVMatches()
    {
        //ToggleMatchingPause(true);
        //ToggleSpawningPause(true);


        CheckColumn(0);
        CheckColumn(1);
        CheckColumn(2);
        CheckColumn(3);
        CheckColumn(4);
        CheckColumn(5);
        CheckColumn(6);
        
        //ToggleSpawningPause(false);
    }

    public void CheckForHMatches()
    {

        CheckRow(6);
        CheckRow(5);
        CheckRow(4);
        CheckRow(3);
        CheckRow(2);
        CheckRow(1);
        CheckRow(0);
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
            MarkChecksForReturn(PossibleChecksC);
        }
    }



    private void CheckRow(int col)
    {
        int currentCountC = 7;

        List<GameObject> PossibleChecksC = new List<GameObject>();
        CandyType lastTypeC = CandyType.NONE;

        var objectsC = GameObject.FindGameObjectsWithTag("Candy");
        var objectCountC = objectsC.Length;
        foreach (var objC in objectsC)
        {
            if (objC.GetComponent<CandyBehaviour>().ColRow.y == col)
            {
                if (currentCountC <= 5 && lastTypeC != objC.GetComponent<CandyBehaviour>().type)
                {
                    MarkChecksForReturn(PossibleChecksC);
                }

                switch (objC.GetComponent<CandyBehaviour>().type)
                {
                    case CandyType.CANDY_RED:
                        if (lastTypeC != CandyType.CANDY_RED)
                        {
                            currentCountC = 7;
                            lastTypeC = CandyType.CANDY_RED;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC--;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_ORANGE:
                        if (lastTypeC != CandyType.CANDY_ORANGE)
                        {
                            currentCountC = 7;
                            lastTypeC = CandyType.CANDY_ORANGE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC--;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_YELLOW:
                        if (lastTypeC != CandyType.CANDY_YELLOW)
                        {
                            currentCountC = 7;
                            lastTypeC = CandyType.CANDY_YELLOW;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC--;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_GREEN:
                        if (lastTypeC != CandyType.CANDY_GREEN)
                        {
                            currentCountC = 7;
                            lastTypeC = CandyType.CANDY_GREEN;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC--;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_BLUE:
                        if (lastTypeC != CandyType.CANDY_BLUE)
                        {
                            currentCountC = 7;
                            lastTypeC = CandyType.CANDY_BLUE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC--;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                    case CandyType.CANDY_PURPLE:
                        if (lastTypeC != CandyType.CANDY_PURPLE)
                        {
                            currentCountC = 7;
                            lastTypeC = CandyType.CANDY_PURPLE;
                            if (PossibleChecksC.Count > 0)
                                PossibleChecksC.Clear();
                        }
                        else
                        {
                            currentCountC--;
                        }
                        PossibleChecksC.Add(objC);
                        break;
                }
            }
        }

        if (PossibleChecksC.Count <=6)
        {
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
