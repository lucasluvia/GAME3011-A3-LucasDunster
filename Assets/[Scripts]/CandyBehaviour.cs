using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBehaviour : MonoBehaviour
{
    GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (!gameController)    // Don't let the game even try to play if the controller doesn't exist.
            return;


        
    }
}
