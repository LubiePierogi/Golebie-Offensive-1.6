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
    public void ButtonUnpause()
    {
        if(Board.instance != null)
        {
            if (Board.instance.cosie == Board.PAUZA)
            {
                if (Board.instance.timeWait > 0f)
                    Board.instance.cosie = Board.CZEKANKO;
                else
                    Board.instance.cosie = Board.GRA;
                Destroy(Board.instance.okno);
                Board.instance.okno = null;
            }
        }
    }

    public void ButtonPause()
    {
        if (Board.instance != null)
        {
            if (Board.instance.cosie == Board.GRA || Board.instance.cosie == Board.CZEKANKO)
            {
                Board.instance.cosie = Board.PAUZA;
                Board.instance.okno = Instantiate(Board.instance.pausePanelPrefab, Board.instance.canvas.transform);
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Zacznij()
    {
        SceneManager.LoadScene("Golebie");
    }
}