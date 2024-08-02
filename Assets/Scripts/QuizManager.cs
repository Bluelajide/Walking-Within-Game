using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QnA> qnAs;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject quizPanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text scoreText;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = qnAs.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        quizPanel.SetActive(false);
        GoPanel.SetActive(true);
        scoreText.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        score += 1;
        qnAs.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        qnAs.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = qnAs[currentQuestion].Answers[i];

            if(qnAs[currentQuestion].CorrectAnswer == i+1)
            {
               options[i].GetComponent<AnswerScript>().isCorrect = true;

            }
        }
    }

    void generateQuestion()
    {
        if(qnAs.Count > 0)
        {
            currentQuestion = Random.Range(0, qnAs.Count);

            QuestionTxt.text = qnAs[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
