using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowBehaviour : MonoBehaviour
{
    public int RowNum;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("CandyRowTrigger"))
        {
            var candy = other.transform.parent.gameObject.GetComponent<CandyBehaviour>();

            if (candy.ColRow.y != RowNum)
                candy.ColRow.y = RowNum;

        }
    }

}
