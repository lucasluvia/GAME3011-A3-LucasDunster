using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private TextMeshProUGUI extractsText;
    [SerializeField] private TextMeshProUGUI scansText;
    [SerializeField] private TextMeshProUGUI pointsText;

    public bool ExtractMode = true; 
    public int remainingScans = 6;
    public int remainingExtracts = 3;

    private int pointTracker = 0;

    private float arraySize = 32;
    private GameObject[,] buttonArray = new GameObject[32, 32];

    public bool debugCanRevealAll = false; 

    void Start()
    {
        InstantiateArray();
        PlaceResources();
        SetButtonText();
        extractsText.text = remainingExtracts.ToString();
        scansText.text = remainingScans.ToString();
        pointsText.text = pointTracker.ToString();
    }

    public void SwapModes()
    {
        ExtractMode = !ExtractMode;
        SetButtonText();
    }

    void SetButtonText()
    {
        if (ExtractMode)
            buttonText.text = "Extract Mode";
        else
            buttonText.text = "Scan Mode";
    }

    public void DecrementUses()
    {
        if(ExtractMode)
        {
            extractsText.text = (--remainingExtracts).ToString();
        }
        else
        {
            scansText.text = (--remainingScans).ToString();
        }
    }

    public void AddToPointTracker(int pointsToAdd)
    {
        pointTracker += pointsToAdd;
        pointsText.text = pointTracker.ToString();
    }

    void InstantiateArray()
    {
        for (int i = 0; i < arraySize; i++)
        {
            var currentRow = transform.Find("Row" + (i + 1));
            int j = 0;
            foreach(Transform column in currentRow)
            {
                buttonArray[i, j] = column.gameObject;
                column.gameObject.GetComponent<ButtonBehaviour>().spotInArray = new Vector2(i, j);
                j++;
            }
        }
    }

    public GameObject GetButtonInArray(Vector2 requestersPosition, Vector2 additivePosition)
    {
        return buttonArray[(int)(requestersPosition.x + additivePosition.x), (int)(requestersPosition.y + additivePosition.y)];
    }

    void PlaceResources()
    {
        for (int i = 0; i < 8; i++)
        {
            int iValue = Random.Range(0, 31);
            int jValue = Random.Range(0, 31);
            Vector2 centreButton = new Vector2(iValue, jValue);

            buttonArray[iValue, jValue].gameObject.GetComponent<ButtonBehaviour>().SetMaterialValue(MaterialValues.FULL);
            
            //first ring
            SetValueIfValid(centreButton,new Vector2(-1, -1), MaterialValues.HALF);
            SetValueIfValid(centreButton,new Vector2(-1,  0), MaterialValues.HALF);
            SetValueIfValid(centreButton,new Vector2(-1, +1), MaterialValues.HALF);
            SetValueIfValid(centreButton,new Vector2(+1, -1), MaterialValues.HALF);
            SetValueIfValid(centreButton,new Vector2(+1,  0), MaterialValues.HALF);
            SetValueIfValid(centreButton,new Vector2(+1, +1), MaterialValues.HALF);
            SetValueIfValid(centreButton,new Vector2( 0, -1), MaterialValues.HALF);
            SetValueIfValid(centreButton,new Vector2( 0, +1), MaterialValues.HALF);
                            
            //second ring   
            SetValueIfValid(centreButton,new Vector2(-2, +1), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(-2, -2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(-2, +2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(+2, -1), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(+2,  0), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(+2, +2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(+2, -2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(+2, +1), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(-2,  0), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2( 0, -2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2( 0, +2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(-1, -2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(-1, +2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(+1, +2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(+1, -2), MaterialValues.QUARTER);
            SetValueIfValid(centreButton,new Vector2(-2, -1), MaterialValues.QUARTER);
        }
    }

    private void SetValueIfValid(Vector2 originButton, Vector2 desiredOffset, MaterialValues valueToSet)
    {
        var offsetSpot = originButton + desiredOffset;
        if (offsetSpot.x >= 0 && offsetSpot.x < 32)
        {
            if (offsetSpot.y >= 0 && offsetSpot.y < 32)
            {
                if(valueToSet < GetButtonInArray(originButton, desiredOffset).gameObject.GetComponent<ButtonBehaviour>().materialValue)
                    GetButtonInArray(originButton,desiredOffset).gameObject.GetComponent<ButtonBehaviour>().SetMaterialValue(valueToSet);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && debugCanRevealAll)
        {
            DebugSetAllButtonsRevealed();
        }
    }

    private void DebugSetAllButtonsRevealed()
    {
        foreach (GameObject button in buttonArray)
        {
            button.GetComponent<ButtonBehaviour>().isRevealed = true;
        }
        debugCanRevealAll = false;
    }

}
