using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziarenko : MonoBehaviour
{
    // Type - 0 - green, 1 - purple 
    public int type = 0;
    // Start is called before the first frame update
    void Start()
    {
        Board.instance.seedsAll.Add(this);
        if (type > 0)
        {
            Board.instance.purpleSeeds.Add(this);
        }
    }

    private void OnDestroy()
    {
        Board.instance.seedsAll.Remove(this);
        if (type > 0)
        {
            Board.instance.purpleSeeds.Remove(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
