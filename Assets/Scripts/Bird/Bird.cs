using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int _score;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void IncreaseScore()
    {
        _score++;
    }

    public void ResetPlayer()
    {
        _score = 0;
        _birdMover.ResetBird();
    }

    public void Die()
    {
        Debug.Log("Player DIE");
        Time.timeScale = 0;
    }
}
