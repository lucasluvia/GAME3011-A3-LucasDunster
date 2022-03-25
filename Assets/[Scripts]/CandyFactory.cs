using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CandyFactory : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GameObject CandyPrefab;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public GameObject createCandy(CandyType type = CandyType.NONE)
    {
        if (type == CandyType.NONE)
        {
            var randomCandy = Random.Range(0, 5);
            type = (CandyType)randomCandy;
        }

        GameObject tempCandy = Instantiate(CandyPrefab);
        tempCandy.GetComponent<CandyBehaviour>().type = type;
        tempCandy.GetComponent<CandyBehaviour>().swapTrigger = true;
        tempCandy.transform.parent = transform;
        tempCandy.SetActive(false);

        return tempCandy;
    }
}
