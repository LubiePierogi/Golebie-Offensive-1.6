using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Stan", menuName = "gra/stan", order = 1)]
public class Stan : ScriptableObject
{
    public Level[] levels;

    public int lvlNumber; // -1 to random xd

    public void PlayButton()
    {
        Debug.Log("hahahaha");
        SceneManager.LoadScene("LevelWybor");
    }

    public void ExitButton()
    {
        Debug.Log("hahahaha xd");
        Application.Quit();
    }


    public void ButtonLevel(int x)
    {
        lvlNumber = x;
        Zacznij();
    }
    public void ButtonRandom()
    {
        lvlNumber = -1;
        Zacznij();
    }
    public void Zacznij()
    {
        SceneManager.LoadScene("Golebie");
    }
}