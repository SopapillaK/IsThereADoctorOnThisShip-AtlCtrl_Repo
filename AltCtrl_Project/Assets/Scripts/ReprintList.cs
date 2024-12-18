using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GameManager;
using UnityEngine.SceneManagement;

public class ReprintList : MonoBehaviour
{
    //public TextMeshProUGUI text;

    public GameObject winPanel;
    public GameObject losePanel;
    void Start()
    {
        PrintList();
        CheckForWin();
    }

    void PrintList()
    {
        string gameName = "";
        foreach (MiniGameStruct s in GameManager.instance.miniGameStructs)
        {
            gameName = gameName + s.ToString() + "\n";
        }
        //text.text = gameName;
    }

    public bool CheckForWin()
    {
        int completGames = 0;
        foreach (MiniGameStruct s in GameManager.instance.miniGameStructs)
        {
            if (s.complete)
            {
                completGames++;
            }
        }

        if (completGames == GameManager.instance.miniGameStructs.Length)
        {
            winPanel.SetActive(true);
            return true;
        }

        if (GameManager.instance.timeRemaining <= 0 && completGames != GameManager.instance.miniGameStructs.Length)
        {
            losePanel.SetActive(true);
            return true;
        }

        return false;
    }
}
