using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    }

    public void OnReplySelected(int replyIndex)
    {
        var question = selectedCategory.questions[currentQuestionIndex];

        if (replyIndex == question.correctReplyIndex)
        {
            Debug.Log("Correct reply!");

            if (question.correctSound != null)
                audioSource.PlayOneShot(question.correctSound);
        }
        else
        {
            Debug.Log("Wrong Reply!");

            if (question.wrongSound != null)
                audioSource.PlayOneShot(question.wrongSound);
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < selectedCategory.questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Quiz Finished");
        }
    }
}