using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject[] questions;
    public int[] correctAnswers;

    private int currentQuestion = 0;

    public void PlayerChoice(int choice)
    {
        if (choice == correctAnswers[currentQuestion])
        {
            Debug.Log("Correct!");

            //Hide current question
            questions[currentQuestion].SetActive(false);

            //Move to next
            currentQuestion++;

            //Check if finished
            if (currentQuestion >= questions.Length)
            {
                SceneManager.LoadScene("Ending");
            }
            else
            {
                questions[currentQuestion].SetActive(true);
            }
        }
        else
        {
            Debug.Log("Wrong!");
            SceneManager.LoadScene("Fired");
        }
    }
}