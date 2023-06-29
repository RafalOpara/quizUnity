using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
     [SerializeField] QuestionSO question;
     [SerializeField] GameObject[] answerButtons;
     int correctAnswerIndex;
     [SerializeField]Sprite defaultAnswerSprite;
     [SerializeField]Sprite correctAnswerSprite;
    // Start is called before the first frame update
    void Start()
    {
        GetNextQuestion();
        //DisplayQuestion();   
    }

    public void OnAnswerSelected(int index)

    {
            Image buttonImage;

        if(index==question.GetCorrectAnswerindex())
        {
            questionText.text="Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex=question.GetCorrectAnswerindex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text="Wrong answer! The correct answer was;\n " + correctAnswer;
            buttonImage=answerButtons[correctAnswerIndex].GetComponent<Image>();
            

        }

        SetButtonState(false);
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
 questionText.text = question.GetQuestion();

        for(int i =0; i<answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i=0; i<answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable=state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i=0; i<answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite=defaultAnswerSprite;
        }
    }

}

