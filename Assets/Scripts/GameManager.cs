using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.Events;

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
        GameState = State.Play;
        DontDestroyOnLoad(gameObject);
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("gameOver");
        }
    }
}
