using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onCorrectAnswer;
    public UnityEvent onWrongAnswer;
    public UnityEvent OnQuizFinished;

    public QuestionData[] categories;
    private QuestionData selectedCategory;
    private int currentQuestionIndex = 0;

    public Image questionImage;
    public Button[] replyButtons;

    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public AudioClip anotherButtonSound;

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
        onCorrectAnswer.AddListener(HandleCorrectAnswer);
        onWrongAnswer.AddListener(HandleWrongAnswer);
        OnQuizFinished.AddListener(HandleQuizFinished);
        
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
    }

    public void OnReplySelected(int replyIndex)
    {
        var question = selectedCategory.questions[currentQuestionIndex];
        bool isCorrect = replyIndex == question.correctReplyIndex;

        if (isCorrect)
            onCorrectAnswer.Invoke();

        else
            onWrongAnswer.Invoke();


        currentQuestionIndex++;

        if (currentQuestionIndex < selectedCategory.questions.Length)
            DisplayQuestion();
        
        else
            OnQuizFinished.Invoke();
    }



    private void HandleCorrectAnswer()
    {
        Debug.Log("Correct!");
        var question = selectedCategory.questions[currentQuestionIndex];
        audioSource.PlayOneShot(question.correctSound);
    }

    private void HandleWrongAnswer()
    {
        Debug.Log("Wrong!");
        var question = selectedCategory.questions[currentQuestionIndex];
        audioSource.PlayOneShot(question.wrongSound);
        SceneManager.LoadScene("Fired");
    }

    private void HandleQuizFinished()
    {
        Debug.Log("Quiz Finished!");
        SceneManager.LoadScene("Ending");
    }
}