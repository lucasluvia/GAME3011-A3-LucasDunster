using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CandyManager : MonoBehaviour
{
    public CandyFactory candyFactory;
    public int MaxCandies;

    private Queue<GameObject> candyPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildCandyPool();
    }

    private void _BuildCandyPool()
    {
        // create empty Queue structure
        candyPool = new Queue<GameObject>();

        for (int count = 0; count < MaxCandies; count++)
        {
            var tempCandy = candyFactory.createCandy();
            candyPool.Enqueue(tempCandy);
        }
    }

    public GameObject GetCandy(Vector3 position, CandyType type, bool isBomb, bool isBlock, int inColumn)
    {
        var newCandy = candyPool.Dequeue();
        newCandy.SetActive(true);
        newCandy.GetComponent<CandyBehaviour>().type = type;
        newCandy.GetComponent<CandyBehaviour>().isBomb = isBomb;
        newCandy.GetComponent<CandyBehaviour>().isBlock = isBlock;
        newCandy.GetComponent<CandyBehaviour>().ColRow.x = inColumn;
        newCandy.GetComponent<CandyBehaviour>().swapTrigger = true;
        newCandy.transform.position = position;
        return newCandy;
    }

    public bool HasCandies()
    {
        return candyPool.Count > 0;
    }

    public void ReturnCandy(GameObject returnedCandy)
    {
        returnedCandy.SetActive(false);
        candyPool.Enqueue(returnedCandy);
    }
}
