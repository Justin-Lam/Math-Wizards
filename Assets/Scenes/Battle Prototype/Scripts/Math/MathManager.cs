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
    [SerializeField] GameObject[] answerResultTexts = new GameObject[5];        // 0. Out of Time   1. Incorrect    2. Good!    3. Great!!  4. MATH EXTRAORDINAIRE!!!

	[Header("Components")]
	[SerializeField] TextMeshProUGUI questionText;
	[SerializeField] TextMeshProUGUI[] answerButtonTexts = new TextMeshProUGUI[4];
	[SerializeField] TextMeshProUGUI greatAnswerResultAbilityPowerIncreaseText;
	[SerializeField] TextMeshProUGUI mathExtraordinaireAnswerResultAbilityPowerIncreaseText;

	[Header("Designer Variables")]
	[SerializeField][Tooltip("Getting a Great!! will result in a math result multiplier of 1 + 1/2 of this number, whereas getting a MATH EXTRAORDINAIRE!!! will result in a math result multiplier of 1 + this number")]
	float mathResultMultiplierRange;

	[Header("Delays")]
	[SerializeField][Tooltip("Amount of time before the timer, question, and answers appear")] float showTimerQuestionAnswersDelay;
    [SerializeField][Tooltip("Amount of time before the result of the answer is revealed")] float showAnswerResultDelay;
    [SerializeField][Tooltip("Amount of time before the the math canvas is hidden")] float returnToBattleDelay;


	void Start()
	{
		// Set the ability power increase texts
		greatAnswerResultAbilityPowerIncreaseText.text = "Ability power increased by " + (100 * mathResultMultiplierRange / 2f) + "%!";
		mathExtraordinaireAnswerResultAbilityPowerIncreaseText.text = "Ability power increased by " + (100 * mathResultMultiplierRange) + "%!";
	}

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
            answerResultTexts[2 + (int)timerScript.CorrectAnswerResult].SetActive(true);

            // Wait for some time
            yield return new WaitForSeconds(returnToBattleDelay);

			// Activate the ability
			float mathResultMultiplier = 1.0f;

			if (timerScript.CorrectAnswerResult == Timer.CorrectAnswerResults.GREAT)
			{
				mathResultMultiplier += mathResultMultiplierRange / 2f;
			}
			else if (timerScript.CorrectAnswerResult == Timer.CorrectAnswerResults.MATH_EXTRAORDINAIRE)
			{
				mathResultMultiplier += mathResultMultiplierRange;
			}

			playerTurnManager.ActivateAbility(mathResultMultiplier);

            // Hide math canvas
            mathCanvasGO.SetActive(false);
		}
		else			// incorrect answer pressed
		{
			// Show "Incorrect"
			answerResultTexts[1].SetActive(true);

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
		// Hide the buttons
		answerButtonPanelGO.SetActive(false);

		// Wait for some time
		yield return new WaitForSeconds(showAnswerResultDelay);

		// Show "Out of Time"
		answerResultTexts[0].SetActive(true);

		// Wait for some time
		yield return new WaitForSeconds(returnToBattleDelay);

		// Subtract an action
		playerTurnManager.subtractAction();

		// Hide math canvas
		mathCanvasGO.SetActive(false);
	}


    public void HideMathCanvas() { mathCanvasGO.SetActive(false); }     // For StartManager to use when setting up the battle
}
