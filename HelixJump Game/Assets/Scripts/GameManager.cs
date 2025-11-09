using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //dados da classe
    public static bool isGameStarted; //indica se o jogo começou
    public static bool gameOver; //indica se o jogo acabou
    public static bool levelCompleted; //indica se o nível foi completado
    public static bool mute = false; //controla o estado do som
    public static int currentLevelIndex; //nível atual do jogo
    public static int numberOfPassedRings; //quantidade de anéis passados
    public static int score = 0; //pontuação atual do jogador
    public static int highScore; //pontuação mais alta alcançada

    //Itens da Hud
    public GameObject gamePlayPanel; //painel do progessBar

    public Slider progressBarSlider; //slider
    public TextMeshProUGUI currentLevelText; //texto do nível atual
    public TextMeshProUGUI nextLevelText; //texto do próximo nível
    public TextMeshProUGUI scoreText;



    // Start is called before the first frame update
    private void Awake()
    {
        //descomente a linha e execute para resetar o jogo
        //PlayerPrefs.SetInt("CurrentLevelIndex", 1);

        //dados pegos da memória do dispositivo 
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    void Start()
    {
        Time.timeScale = 1; //desativando o pause no jogo
        gameOver = false; //iniciando o jogo como não acabado
        levelCompleted = false; //iniciando o nível como não completado
        isGameStarted = false; //iniciando o jogo como não começado
        numberOfPassedRings = 0; //zerando a quantidade de anéis passados
    }

    // Update is called once per frame
    void Update()
    {
        //implemantar HUD
        //informar o nível atual e o score
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();
        scoreText.text = score.ToString();

        //altera o valor da barra de progesso
        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        progressBarSlider.value = progress;

        //controlar o inicio de jogo

        //controlar o fim de jogo
        if (gameOver)
        {
            Time.timeScale = 0; //pausando o jogo
            //controlar a cena e exibir o high score
            //IMPLEMENTAR mecânica de pontuação 

            //desktop
            if (Input.GetButton("Fire1"))
            {
                GameManager.score = 0;
                SceneManager.LoadScene(0);
            }

            //IMPLEMENTAR versão mobile
        }

        if (levelCompleted)
        {
            Time.timeScale = 0;
            //controlar a cena e exibir o reinicio de jogo
            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex+1);

            //desktop
            if (Input.GetButton("Fire1"))
            { 
                SceneManager.LoadScene(0);
            }

            //IMPLEMENTAR versão mobile
        }
    }
}
