using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Canvas worldCanvas;
    [SerializeField] private Canvas gameCanvas;

    GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        worldCanvas.enabled = true;
        gameCanvas.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwapCanvases();
            gameController.ToggleSpawningPause(worldCanvas.enabled);
        }
    }

    private void SwapCanvases()
    {
        worldCanvas.enabled = !worldCanvas.enabled;
        gameCanvas.enabled = !gameCanvas.enabled;
    }
}
