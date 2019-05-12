using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "gra/level", order = 2)]
public class Level : ScriptableObject
{
    public List<Vector2> ptaks;
    public List<Vector2> ziarenkos;
    public float time;
    public int seedsInPlecak;
    
    public Level(List<Vector2> pt, List<Vector2> zr, float tm, int pl)
    {
        ptaks = new List<Vector2>(pt);
        ziarenkos = new List<Vector2>(zr);
        time = tm;
        seedsInPlecak = pl;
    }

    public Level()
    {
        ptaks = new List<Vector2>();
        ziarenkos = new List<Vector2>();
        time = 1;
        seedsInPlecak = 0;
    }
}
