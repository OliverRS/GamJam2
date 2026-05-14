using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;

        Debug.Log("Score: " + score);
    }

    public int GetScore()
    {
        return score;
    }

    private void OnEnable()
    {
        GameManager.OnCorrectAnswer += AddPoints;
    }

    private void OnDisable()
    {
        GameManager.OnCorrectAnswer -= AddPoints;
    }

    private void AddPoints()
    {
        score += 5;

        Debug.Log("Score: " + score);
    }
}