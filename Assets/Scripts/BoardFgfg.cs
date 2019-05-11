using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFgfg : MonoBehaviour
{
    public SeedPlansza sp = null;
    public Camera c = null;
    public GameObject sciany = null;
    public Stan stan = null;
    public GameObject ptakPrefab = null;
    public GameObject purpleSeedPrefab = null;
    public int seeds = 4;
    public bool jabka = true;
    // Start is called before the first frame update
    void Start()
    {
        if (sp != null)
        {
            sp.c = c;
            sp.fg = this;
        }
        if (jabka)
        {
            if (stan.ptaks != null)
                foreach (Vector2 v in stan.ptaks)
                {
                    GameObject ptak = Instantiate(ptakPrefab);
                    ptak.transform.position = v;
                }
            if (stan.purpleSeeds != null)
                foreach (Vector2 v in stan.purpleSeeds)
                {
                    GameObject purpleSeed = Instantiate(purpleSeedPrefab);
                    purpleSeed.transform.position = v;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
