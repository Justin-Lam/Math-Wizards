using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public enum CorrectAnswerResults { GOOD, GREAT, MATH_EXTRAORDINAIRE }

	[SerializeField] MathManager mathManager;
	[SerializeField] Slider leftTimer;
	[SerializeField] Slider rightTimer;

	[SerializeField][Tooltip("Number of seconds timer runs for")] float timeLimit;
	float timeLeft;
	bool isActive;
	CorrectAnswerResults correctAnswerResult;       public CorrectAnswerResults CorrectAnswerResult => correctAnswerResult;

	public IEnumerator Activate()
	{
		// Setup
		timeLeft = timeLimit;
		isActive = true;

		// Start timer
		while (isActive && timeLeft > 0f)
		{
			leftTimer.value = timeLeft / timeLimit;
			rightTimer.value = timeLeft / timeLimit;

			yield return null;		// wait for the next frame

			timeLeft -= Time.deltaTime;
		}

		// Timer deactivated or out of time
		if (isActive)		// ran out of time
		{
			isActive = false;
			StartCoroutine(mathManager.OutOfTime());
		}
	}

	public void Deactivate()
	{
		// Deactivate
		isActive = false;

		// Calculate and set answerTimeResult
		float timeLeftRatio = timeLeft / timeLimit;
		if (timeLeftRatio >= 0f && timeLeftRatio < 1f / 3f)				{ correctAnswerResult = CorrectAnswerResults.GOOD; }
		else if (timeLeftRatio >= 1f / 3f && timeLeftRatio < 2f / 3f)	{ correctAnswerResult = CorrectAnswerResults.GREAT; }
		else															{ correctAnswerResult = CorrectAnswerResults.MATH_EXTRAORDINAIRE; }
	}
}