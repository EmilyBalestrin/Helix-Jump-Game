using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonsEvents : MonoBehaviour
{
    public TextMeshPro muteText;
    public GameObject gameMenuPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        GameManager.isGameStarted = true;
        gameMenuPanel.SetActive(false);
    }

    //sai do jogo
    public void QuitGame()
    {
        Application.Quit();
    }
}
