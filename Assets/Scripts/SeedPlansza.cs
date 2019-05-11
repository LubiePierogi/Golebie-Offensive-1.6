using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPlansza : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Board.instance.c != null)
        {
            if (Board.instance.seeds > 0 && Board.instance.greenSeedPrefab != null)
            {
                Vector3 q = Board.instance.c.ScreenToWorldPoint(Input.mousePosition); // screen to world
                q.Scale(Vector3.up + Vector3.right);
                --Board.instance.seeds;
                GameObject newSeed = Instantiate(Board.instance.greenSeedPrefab);
                newSeed.transform.position = q;
            }

        }
    }
}
