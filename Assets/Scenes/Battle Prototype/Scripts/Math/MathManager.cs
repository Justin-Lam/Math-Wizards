using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] PlayerTurnManager playerTurnManager;

	[Header("Math Scripts")]
	[SerializeField] Questions questionsScript;
    [SerializeField] Answers answersScript;
    [SerializeField] Timer timerScript;

	[Header("Game Objects")]
	[SerializeField] GameObject mathCanvasGO;
    [SerializeField] GameObject timerGO;
    [SerializeField] GameObject questionTextGO;
    [SerializeField] GameObject answerButtonPanelGO;
    [SerializeField] GameObject[] answerResultTexts = new GameObject[4];

	[Header("Components")]
	[SerializeField] TextMeshProUGUI questionText;
	[SerializeField] TextMeshProUGUI[] answerButtonTexts = new TextMeshProUGUI[4];

	[Header("Delays")]
	[SerializeField][Tooltip("Amount of time before the timer, question, and answers appear")] float showTimerQuestionAnswersDelay;
    [SerializeField][Tooltip("Amount of time before the result of the answer is revealed")] float showAnswerResultDelay;
    [SerializeField][Tooltip("Amount of time before the the math canvas is hidden")] float returnToBattleDelay;


	public IEnumerator GiveMathExercise()
    {
        // Show "QUESTION:"
        mathCanvasGO.SetActive(true);

        // Hide everything else
        timerGO.SetActive(false);
        questionTextGO.SetActive(false);
        answerButtonPanelGO.SetActive(false);
        foreach (GameObject textGO in answerResultTexts) { textGO.SetActive(false); }

        // Wait for some time
        yield return new WaitForSeconds(showTimerQuestionAnswersDelay);

        // Show timer, question, and answers
        timerGO.SetActive(true);
        questionTextGO.SetActive(true);
        answerButtonPanelGO.SetActive(true);

        // Generate the question
        questionsScript.GenerateQuestion();

        // Display the question
        questionText.text = $"{questionsScript.X} {questionsScript.MathOperator} {questionsScript.Y} = ???";

		// Generate the answers
		answersScript.GenerateAnswers(questionsScript.Answer);

        // Display the answers
        for (int i = 0; i < 4; i++) { answerButtonTexts[i].text = answersScript.AnswerValues[i].ToString(); }

        // Activate the timer
        StartCoroutine(timerScript.Activate());
    }

    public void OnAnswer1Selected() { StartCoroutine(AnswerSelected(answersScript.AnswerResults[0])); }
	public void OnAnswer2Selected() { StartCoroutine(AnswerSelected(answersScript.AnswerResults[1])); }
	public void OnAnswer3Selected() { StartCoroutine(AnswerSelected(answersScript.AnswerResults[2])); }
	public void OnAnswer4Selected() { StartCoroutine(AnswerSelected(answersScript.AnswerResults[3])); }
	public IEnumerator AnswerSelected(bool result)
	{
        // Hide the buttons
        answerButtonPanelGO.SetActive(false);

        // Deactivate the timer
        timerScript.Deactivate();

        // Wait for some time
        yield return new WaitForSeconds(showAnswerResultDelay);

		if (result)		// correct answer pressed
		{
            // Show good, great, or amazing
            answerResultTexts[2].SetActive(true);       // "Great!"

            // Wait for some time
            yield return new WaitForSeconds(returnToBattleDelay);

            // Activate the ability
            playerTurnManager.ActivateAbility(1.0f);

            // Hide math canvas
            mathCanvasGO.SetActive(false);
		}
		else			// incorrect answer pressed
		{
			// Show "Incorrect"
			answerResultTexts[0].SetActive(true);

			// Wait for some time
			yield return new WaitForSeconds(returnToBattleDelay);

            // Subtract an action
            playerTurnManager.subtractAction();

			// Hide math canvas
			mathCanvasGO.SetActive(false);
		}
	}

    public IEnumerator OutOfTime()
    {
        yield return null;
    }


    public void HideMathCanvas() { mathCanvasGO.SetActive(false); }     // For StartManager to use when setting up the battle
}
