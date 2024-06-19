using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum State
{
    Play,
    GameOver,
    Pause
}
public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;
    [SerializeField] private float _timer;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = value;
            timerText.text = $"Timer : {(int)value}";
        }
    }
    [SerializeField] private int _score = 0;
    private GameObject _player;
    private GameObject _animalSpawner;
    public int Score {
        get => _score;
        set
        {
            _score = value;
            scoreText.text = $"Score : {value}";
        }
    }
    public State GameState;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text timerText;

    public GameObject PlayUI;
    public GameObject GameOverUI;
    private void Start()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        StartGame();
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        Timer = 60;
        Score = 0;
        GameState = State.Play;
        _player = GameObject.FindGameObjectWithTag("Player");
        _animalSpawner = GameObject.FindGameObjectWithTag("Animal Spawner");
        PlayUI = GameObject.FindGameObjectWithTag("Play UI");
        GameOverUI = GameObject.FindGameObjectWithTag("Game Over UI");
        scoreText = GameObject.FindGameObjectWithTag("Score UI").GetComponent<TMP_Text>();
        timerText = GameObject.FindGameObjectWithTag("Timer UI").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(GameState == State.Play)
            {
                Time.timeScale = 0;
                GameState = State.Pause;
            }
            else if(GameState == State.Pause)
            {
                Time.timeScale = 1;
                GameState = State.Play;
            }
        }

        if(GameState == State.Play)
        {
            if(Timer > 1)
            {
                Timer = Mathf.Max(Timer-Time.deltaTime,0);
            }
            else
            {
                GameState = State.GameOver;
            }
        }
        else if(GameState == State.GameOver)
        {
            PlayUI.SetActive(false);
            GameOverUI.SetActive(true);
            GameObject.FindGameObjectWithTag("Score Game Over UI").GetComponent<TMP_Text>().text = $"Score: {Score}";
            _player.GetComponent<Animator>().SetTrigger("gameOver");
            _player.GetComponent<PlayerMovementController>().enabled = false;
            _player.GetComponent<PlayerThrowController>().enabled = false;
            _animalSpawner.SetActive(false);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Destroy(this);
    }
}
