using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board instance;
    public SeedPlansza sp = null;
    public Camera c = null;
    public GameObject sciany = null;
    public Stan stan = null;
    public GameObject ptakPrefab = null;
    public GameObject purpleSeedPrefab = null;
    public GameObject greenSeedPrefab = null;
    public bool nieee = false;
    public int seeds = 4;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("xdxdxd");
        Level lvl;
        if (stan.lvlNumber >= 0)
        {
            lvl = stan.levels[stan.lvlNumber - 1];
        }
        else
        {
            lvl = new Level();
        }
        //Debug.Log("xdxdxd10 level " + stan.lvlNumber);
        foreach (Vector2 vec in lvl.ptaks)
        {
            GameObject ptak = Instantiate(ptakPrefab);
            ptak.transform.position = vec;
            //Debug.Log("12#");
        }
        foreach (Vector2 vec in lvl.ziarenkos)
        {
            GameObject ziarenko = Instantiate(purpleSeedPrefab);
            ziarenko.transform.position = vec;
            // Debug.Log("12$");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        instance = this;// FindObjectOfType<Board>();
    }


}
