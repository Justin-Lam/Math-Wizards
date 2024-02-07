using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
	[SerializeField] UIHUDManager uiHudManager;
	[SerializeField][Tooltip("Amount of time before the timer, question, and answers appear")] float waitTime;

	int x;
	int y;
	int answer;

	public IEnumerator GiveMathQuestion()
	{
		// Show the math canvas
		uiHudManager.ShowMathCanvas();

		// Hide the question and answers
		uiHudManager.HideTimerQuestionAnswers();

		// Wait for some time
		yield return new WaitForSeconds(waitTime);

		// Show the question and answers
		uiHudManager.ShowTimerQuestionAnswers();

		// Generate the question and answer
		x = Random.Range(1, 20);
		y = Random.Range(1, 20);
		answer = x + y;

		// Display the question
		uiHudManager.SetQuestionText(x + " + " + y + " = ???");

		// Set the answer buttons
		uiHudManager.SetAnswers(answer);

		// Start the timer
		uiHudManager.ActivateTimer();
	}
}
