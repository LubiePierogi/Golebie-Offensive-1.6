using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPlansza : MonoBehaviour
{
    public Camera c = null;
    public BoardFgfg fg = null;
    public GameObject putSeedPrefab = null;
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
        if (c != null)
        {
            if (fg.seeds > 0 && putSeedPrefab != null)
            {
                Vector3 q = c.ScreenToWorldPoint(Input.mousePosition); // screen to world
                q.Scale(Vector3.up + Vector3.right);
                --fg.seeds;
                GameObject newSeed = Instantiate(putSeedPrefab);
                newSeed.transform.position = q;
            }

        }
    }
}
