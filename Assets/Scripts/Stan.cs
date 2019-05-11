using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Stan", menuName = "gra/stan", order = 1)]
public class Stan : ScriptableObject
{
    /// <summary>
    /// Board which we play now on.
    /// </summary>
    /// Can be null xd
    public BoardFgfg board = null;

    public Vector2[] ptaks = null;
    public Vector2[] purpleSeeds = null;

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

    
    public void ButtonLevel(int levelNumer)
    {
        switch (levelNumer)
        {
            case 1:
                purpleSeeds = new Vector2[]
                {
                    new Vector2(3f, 4f),
                    new Vector2(4f, 3.2f),
                    new Vector2(5f, -5f),
                    new Vector2(6f, -4f),
                };
                ptaks = new Vector2[]
                {
                    new Vector2(5f, 8f),
                    new Vector2(-4.35f, 0f),
                };
                break;
            case 2:
                Debug.Log("Wybieranie levelu 2 xd");
                break;
            case 3:
                Debug.Log("Wybieranie levelu 3 xd");
                break;
            default:
                Debug.Log("Nie ma takiego levelu xd\n nic nie robię xd");
                return;
        }
        ZacznijXd();
    }
    public void ButtonRandom()
    {
        Debug.Log("ok, to mam zrobić losowy level xd");
        ZacznijXd();
    }
    private void ZacznijXd()
    {
        SceneManager.LoadScene("Golebie");
    }
}
