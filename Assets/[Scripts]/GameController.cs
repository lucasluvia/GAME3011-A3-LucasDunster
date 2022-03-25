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

    public void SwapTiles(CandyBehaviour c1, CandyBehaviour c2)
    {
        if ((c1.type == CandyType.BOX || c1.type == CandyType.NONE) || 
            (c2.type == CandyType.BOX || c2.type == CandyType.NONE) ||
            (c1.type == c2.type))
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
