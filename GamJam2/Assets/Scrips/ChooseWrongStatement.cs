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

            //Set the current question inactive
            questions[currentQuestion].SetActive(false);

            //Move to next question
            currentQuestion++;

            //Check if it is finished
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