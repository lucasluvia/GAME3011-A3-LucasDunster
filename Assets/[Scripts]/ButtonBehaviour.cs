using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public GameController gameControllerRef;
    public MaterialValues materialValue;
    public Vector2 spotInArray = new Vector2(0, 0);
    private Color HiddenValueColor = Color.white;
    private Color FullValueColour = Color.blue;
    private Color HalfValueColour = new Color(0f, 0.4f, 1f, 1f);
    private Color QuarterValueColour = new Color(0f, 0.6f, 1f, 1f);
    private Color EmptyValueColour = new Color(0.7f, 0.7f, 0.7f, 1f);

    private Image image;

    private Color MaterialValueColour;
    private int pointValue;

    public bool isRevealed;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerRef = transform.parent.parent.GetComponent<GameController>();
        SetMaterialValueVariables();
        image = GetComponent<Image>();
        image.color = HiddenValueColor;
        gameObject.GetComponent<Button>().onClick.AddListener(wasClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRevealed)
        {
            image.color = MaterialValueColour;
        }
    }

    public void SetMaterialValue(MaterialValues newValue)
    {
        materialValue = newValue;
        SetMaterialValueVariables();
    }

    void SetMaterialValueVariables()
    {
        switch(materialValue)
        {
            case MaterialValues.FULL:
                MaterialValueColour = FullValueColour;
                pointValue = 500;
                break;
            case MaterialValues.HALF:
                MaterialValueColour = HalfValueColour;
                pointValue = 250;
                break;
            case MaterialValues.QUARTER:
                MaterialValueColour = QuarterValueColour;
                pointValue = 125;
                break;
            case MaterialValues.EMPTY:
                MaterialValueColour = EmptyValueColour;
                pointValue = 0;
                break;
        }
    }

    void ExtractSelfMaterial()
    {
        gameControllerRef.AddToPointTracker(pointValue);
        materialValue = MaterialValues.EMPTY;
        SetMaterialValueVariables();
    }

    public void wasClicked()
    {

        if(gameControllerRef.remainingExtracts >0)
        {
            if (gameControllerRef.ExtractMode)
            {
                if (gameControllerRef.remainingExtracts > 0)
                    CallExtract();
            }
            else
            {
                if (gameControllerRef.remainingScans > 0)
                    CallReveal();
            }
        }

    }

    void DecrementMaterialLevel()
    {

        switch (materialValue)
        {
            case MaterialValues.FULL:
                SetMaterialValue(MaterialValues.HALF);
                break;
            case MaterialValues.HALF:
                SetMaterialValue(MaterialValues.QUARTER);
                break;
            case MaterialValues.QUARTER:
                SetMaterialValue(MaterialValues.EMPTY);
                break;
        }
    }

    void CallExtract()
    {
        ExtractSelfMaterial();

        TriggerDecrement(new Vector2(-1, -1));
        TriggerDecrement(new Vector2(-1,  0));
        TriggerDecrement(new Vector2(-1, +1));
        TriggerDecrement(new Vector2(-1, -2));
        TriggerDecrement(new Vector2(-1, +2));
        TriggerDecrement(new Vector2(+1, -1));
        TriggerDecrement(new Vector2(+1,  0));
        TriggerDecrement(new Vector2(+1, +2));
        TriggerDecrement(new Vector2(+1, -2));
        TriggerDecrement(new Vector2(+1, +1));
        TriggerDecrement(new Vector2(-2, -1));
        TriggerDecrement(new Vector2(-2,  0));
        TriggerDecrement(new Vector2(-2, +1));
        TriggerDecrement(new Vector2(-2, -2));
        TriggerDecrement(new Vector2(-2, +2));
        TriggerDecrement(new Vector2(+2, -1));
        TriggerDecrement(new Vector2(+2,  0));
        TriggerDecrement(new Vector2(+2, +2));
        TriggerDecrement(new Vector2(+2, -2));
        TriggerDecrement(new Vector2(+2, +1));
        TriggerDecrement(new Vector2( 0, -1));
        TriggerDecrement(new Vector2( 0, +1));
        TriggerDecrement(new Vector2( 0, -2));
        TriggerDecrement(new Vector2( 0, +2));

        gameControllerRef.DecrementUses();
    }

    void CallReveal()
    {
        RevealSelf();

        TriggerReveal(new Vector2(-1, -1));
        TriggerReveal(new Vector2(-1,  0));
        TriggerReveal(new Vector2(-1, +1));
        TriggerReveal(new Vector2(+1, -1));
        TriggerReveal(new Vector2(+1,  0));
        TriggerReveal(new Vector2(+1, +1));
        TriggerReveal(new Vector2( 0, -1));
        TriggerReveal(new Vector2( 0, +1));

        gameControllerRef.DecrementUses();
    }

    void TriggerReveal(Vector2 desiredOffset)
    {
        var offsetSpot = spotInArray + desiredOffset;
        if (offsetSpot.x >= 0 && offsetSpot.x < 32)
        {
            if(offsetSpot.y >= 0 && offsetSpot.y < 32)
            {
                gameControllerRef.GetButtonInArray(spotInArray,desiredOffset).GetComponent<ButtonBehaviour>().RevealSelf();
            }
        }
    }

    void TriggerDecrement(Vector2 desiredOffset)
    {
        var offsetSpot = spotInArray + desiredOffset;
        if (offsetSpot.x >= 0 && offsetSpot.x < 32)
        {
            if(offsetSpot.y >= 0 && offsetSpot.y < 32)
            {
                gameControllerRef.GetButtonInArray(spotInArray,desiredOffset).GetComponent<ButtonBehaviour>().DecrementMaterialLevel();
            }
        }
    }



    void RevealSelf()
    {
        isRevealed = true;
    }

}
