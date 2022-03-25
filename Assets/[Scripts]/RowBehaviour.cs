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
            if (other.gameObject.GetComponent<CandyBehaviour>())
                other.gameObject.GetComponent<CandyBehaviour>().ColRow.y = RowNum;

            Debug.Log("Collided with Candy's Row Trigger");
        }
    }

}
