using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorHand;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += ShowTutor;
        _gameOverScreen.RestartButtonClecked += ShowTutor;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= ShowTutor;
        _gameOverScreen.RestartButtonClecked -= ShowTutor;
    }

    private void ShowTutor()
    {
        StartCoroutine(TurnOffTutor());
    }

    private IEnumerator TurnOffTutor()
    {
        _tutorHand.SetActive(true);

        yield return new WaitForSeconds(4);
        _tutorHand.SetActive(false);
    }
}