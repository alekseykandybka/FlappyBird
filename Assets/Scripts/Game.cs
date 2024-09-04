using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private bool _isGameRun = false;

    public bool IsGameRun => _isGameRun;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClecked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClecked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pipeGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        _isGameRun = true;
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    private void OnGameOver()
    {
        _isGameRun = false;
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}