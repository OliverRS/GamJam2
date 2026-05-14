using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public QuestionData[] categories;
    private QuestionData selectedCategory;
    private int currentQuestionIndex = 0;

    public Image questionImage;
    public Button[] replyButtons;

    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public AudioClip anotherButtonSound;

    public static event Action OnCorrectAnswer;
    public static event Action OnWrongAnswer;


    public float timePerQuestion = 15f;
    private float currentTime;
    public TMP_Text timerText;
    private bool isTimerRunning = false;



    

    public void PlayButtonClick()
    {
        if (buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
    }
    public void PlayAnotherButtonSound()
    {
        if (anotherButtonSound != null)
            audioSource.PlayOneShot(anotherButtonSound);
    }


    void Start()
    {
        SelectCategory(0);
    }

    public void SelectCategory(int categoryIndex)
    {
        selectedCategory = categories[categoryIndex];
        currentQuestionIndex = 0;
        DisplayQuestion();
    }

    public void DisplayQuestion()
    {
        if (selectedCategory == null) return;

        var question = selectedCategory.questions[currentQuestionIndex];
        questionImage.sprite = question.questionImage;

        for (int i = 0; i < replyButtons.Length; i++)
        {
            TMP_Text buttonText = replyButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = question.replies[i];
        }

        // Starter timeren
        currentTime = timePerQuestion;
        isTimerRunning = true;
    }

    public void OnReplySelected(int replyIndex)
    {
        isTimerRunning = false;
        var question = selectedCategory.questions[currentQuestionIndex];

        if (replyIndex == question.correctReplyIndex)
        {
            Debug.Log("Correct reply!");
            audioSource.PlayOneShot(question.correctSound);
            OnCorrectAnswer?.Invoke();
        }
        else
        {
            Debug.Log("Wrong Reply!");
            audioSource.PlayOneShot(question.wrongSound);
            SceneManager.LoadScene("Fired");
            OnWrongAnswer?.Invoke();
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < selectedCategory.questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            SceneManager.LoadScene("Ending");
            Debug.Log("Quiz Finished");
        }
    }
    void Update()
    {
        if (!isTimerRunning) return;

        currentTime -= Time.deltaTime;

        timerText.text = Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 0)
        {
            TimeUp();
        }
        if (currentTime <= 5f)
        {
            timerText.color = Color.red;
        }
        else
        {
        timerText.color = Color.white;
        }
    }
    void TimeUp()
    {
        isTimerRunning = false;

        Debug.Log("Ikke mere tid tilbage");
        SceneManager.LoadScene("Fired");
    }
}