using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CandyBehaviour : MonoBehaviour
{
    GameController gameController;
    public Image image;
    GameObject column;

    public CandyType type = CandyType.NONE;
    public bool swapTrigger = true;
    public bool isBomb = false;
    public bool isBlock = false;

    public bool isSelected;
    public bool markedForReturn;

    public Vector2 ColRow;

    public bool isClickable;
    
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        column = transform.parent.gameObject;
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (!gameController)    // Don't let the game even try to play if the controller doesn't exist.
            return;

        if(swapTrigger)
        {
            UpdateCandyImage();
            swapTrigger = false;
        }
    }

    public void UpdateCandyImage()
    {
        if(!isBomb)
        {
            switch (type)
            {
                case CandyType.CANDY_RED:
                    image.sprite = gameController.RedCandy;
                    break;
                case CandyType.CANDY_ORANGE:
                    image.sprite = gameController.OrangeCandy;
                    break;
                case CandyType.CANDY_YELLOW:
                    image.sprite = gameController.YellowCandy;
                    break;
                case CandyType.CANDY_GREEN:
                    image.sprite = gameController.GreenCandy;
                    break;
                case CandyType.CANDY_BLUE:
                    image.sprite = gameController.BlueCandy;
                    break;
                case CandyType.CANDY_PURPLE:
                    image.sprite = gameController.PurpleCandy;
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case CandyType.CANDY_RED:
                    image.sprite = gameController.RedBomb;
                    break;                                  
                case CandyType.CANDY_ORANGE:
                    image.sprite = gameController.OrangeBomb;
                    break;                                  
                case CandyType.CANDY_YELLOW:
                    image.sprite = gameController.YellowBomb;
                    break;                                  
                case CandyType.CANDY_GREEN:                 
                    image.sprite = gameController.GreenBomb;
                    break;                                  
                case CandyType.CANDY_BLUE:                  
                    image.sprite = gameController.BlueBomb;
                    break;                                  
                case CandyType.CANDY_PURPLE:                
                    image.sprite = gameController.PurpleBomb;
                    break;
            }

        }
        
    }

    public void OnCandyClicked()
    {
        gameController.SelectedCandies.Add(gameObject);
    }

}
