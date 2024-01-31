using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Questions : MonoBehaviour
{
	[SerializeField] BattleManager2 battleManager;

	int x;
	int y;
	int answer;

	public void GiveMathQuestion()
	{
		// Show the timer and start it
		battleManager.timer.SetActive(true);
		StartCoroutine(battleManager.timer.GetComponent<Timer>().ActivateTimer());

		// Generate the question and answer
		//GenerateQuestion();
		int x = Random.Range(1, 20);
		int y = Random.Range(1, 20);
		int answer = x + y;

		// Display the question
		battleManager.dialogueText.text = x + " + " + y + " = ???";

		// Show and set the answers
		battleManager.answers.SetActive(true);
		battleManager.answers.GetComponent<Answers>().SetAnswers(answer);
	}

	void GenerateQuestion()
	{
		
	}
}
