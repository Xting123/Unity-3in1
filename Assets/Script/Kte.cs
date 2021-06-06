using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kte : MonoBehaviour
{
    public InputField playerAnswerUI;
    public int playerAnswer;
    public int correctAnswer;
    public Text hintMessage;
    public Button restartButton;

    void Start()
    {
        NewQuestion();
    }

    void UpdateHintMessage(string message)
    {
        hintMessage.text = message;
    }

    void NewQuestion()
    {
        UpdateHintMessage("請輸入0到99之間的數字");
        correctAnswer = Random.Range(0, 100);
        restartButton.gameObject.SetActive(false);
    }

    bool CanGetInputNumber()
    {
        return int.TryParse(playerAnswerUI.text, out playerAnswer);
    }

    public void CompareNumbers()
    {
        
        if (!CanGetInputNumber())
        {
            UpdateHintMessage("只能輸入數字喔");
            return;
        }

        if (playerAnswer == correctAnswer)
        {
            UpdateHintMessage("恭喜你答對了");
            restartButton.gameObject.SetActive(true);
        }

        if (playerAnswer > correctAnswer)
        {
            UpdateHintMessage("答案還要再小一點");
        }

        if (playerAnswer < correctAnswer)
        {
            UpdateHintMessage("答案還要再大一點");
        }
        FocusPlayerAnswerUI();
    }

    public void ClearHintMessage()
    {
        UpdateHintMessage("");
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void FocusPlayerAnswerUI()
    {
        playerAnswerUI.ActivateInputField();
    }
    void Update()
    {

    }
}