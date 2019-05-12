using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    public const float maxWidth = 7f;
    public const float maxHeight = 3f;

    public const int CZEKANKO = 0;
    public const int GRA = 1;
    public const int PAUZA = 2;
    public const int PRZEGRANKO = 3;
    public const int GAME_OVER_OKNO = 4;

    public static Board instance;
    public SeedPlansza sp = null;
    public Camera c = null;
    public GameObject sciany = null;
    public Stan stan = null;
    public GameObject ptakPrefab = null;
    public GameObject purpleSeedPrefab = null;
    public GameObject greenSeedPrefab = null;
    public GameObject pausePanelPrefab = null;
    public GameObject gameOverPanelPrefab = null;
    public Canvas canvas;
    public int cosie = CZEKANKO;
    public bool przegranko = false;
    public int seeds = 4;
    public float timeLeft = 1.00f;
    public float timeToGameOver = 1.00f;
    public float timeWait = 1.00f;
    public Image obrazek = null;

    public List<Ziarenko> purpleSeeds;
    public List<Ziarenko> seedsAll;

    public Text ziarnaText;
    public Text czasText;

    public GameObject okno;

    static Vector2 RandVec()
    {
        return new Vector2(Random.value * 2f * maxWidth - maxWidth, Random.value * 2f * maxHeight - maxHeight);
    }

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
            lvl = Level.CreateInstance<Level>();
            for (int i = 0; i < 8; ++i)
            {
                lvl.ziarenkos.Add(RandVec());
            }
            for (int i = 0; i < 5; ++i)
            {
                lvl.ptaks.Add(RandVec());
            }
            lvl.time = 10;
            lvl.seedsInPlecak = 6;
        }
        //Debug.Log("xdxdxd10 level " + stan.lvlNumber);
        timeLeft = lvl.time;
        seeds = lvl.seedsInPlecak;
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
        czasText.text = string.Format("{0:0.00}", timeLeft);
        ziarnaText.text = string.Format("{0}", seeds);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cosie == GRA || cosie == CZEKANKO)
            {
                stan.ButtonPause();
            }
            else if (cosie == PAUZA)
            {
                stan.ButtonUnpause();
            }
            else if (cosie == GAME_OVER_OKNO)
            {
                stan.MainMenu();
            }
        }
        switch (cosie)
        {
            case GRA:
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0f || !purpleSeeds.Any())
                {
                    cosie = PRZEGRANKO;
                    Destroy(obrazek);
                    timeToGameOver = 1f;
                }
                else
                {
                    czasText.text = string.Format("{0:0.00}", timeLeft);
                    ziarnaText.text = string.Format("{0}", seeds);
                }
                break;
            case PAUZA:
                break;
            case PRZEGRANKO:
                czasText.text = "";
                ziarnaText.text = "";
                timeToGameOver -= Time.deltaTime;
                if (timeToGameOver < 0f)
                {
                    cosie = GAME_OVER_OKNO;
                    //Debug.Log("xd");
                    okno = Instantiate(gameOverPanelPrefab, canvas.transform);
                    GameObject.FindGameObjectsWithTag("punkty")[0].GetComponent<Text>().text = purpleSeeds.Count.ToString();
                }
                break;
            case CZEKANKO:
                timeWait -= Time.deltaTime;
                if(timeWait < 0f)
                {
                    cosie = GRA;
                }
                break;
        }
    }

    void Awake()
    {
        if (purpleSeeds == null)
        {
            purpleSeeds = new List<Ziarenko>();
        }
        if (seedsAll == null)
        {
            seedsAll = new List<Ziarenko>();
        }
        instance = this;// FindObjectOfType<Board>();
    }

    
    /*
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }*/


}
