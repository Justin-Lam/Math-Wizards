using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answers : MonoBehaviour
{
	[SerializeField] int wrongAnswerMaxDifference;
	[SerializeField] PlayerTurnManager playerTurnManager;

	bool answer1Result;
	bool answer2Result;
	bool answer3Result;
	bool answer4Result;

	public void SetAnswers(int num)
	{
		// Select a button to hold the correct answer
		int correctAnswer = Random.Range(0, 3);

		// Loop over every answer buttons
		for (int i = 0; i < this.transform.childCount; i++)
		{
			// Get the GameObject
			GameObject answer = this.transform.GetChild(i).gameObject;

			// Set the text and result
			if (i  == correctAnswer)
			{
				answer.GetComponentInChildren<TextMeshProUGUI>().text = num.ToString();
				SetAnswerResult(i, true);
			}
			else
			{
				int wrongAnswerNum = num + Random.Range(-wrongAnswerMaxDifference, wrongAnswerMaxDifference);
				// TODO: Need to make it so there can't be duplicate wrong answers
				while(wrongAnswerNum == num)
				{
					wrongAnswerNum = num + Random.Range(-wrongAnswerMaxDifference, wrongAnswerMaxDifference);
				}

				answer.GetComponentInChildren<TextMeshProUGUI>().text = wrongAnswerNum.ToString();
				SetAnswerResult(i, false);
			}
		}
	}
	void SetAnswerResult(int i, bool result)
	{
		switch(i)
		{
			case 0:
				answer1Result = result;
				break;
			case 1:
				answer2Result = result;
				break;
			case 2:
				answer3Result = result;
				break;
			case 3:
				answer4Result = result;
				break;
			default:		// should never happen
				return;
		}
	}

	public void OnAnswer1Button()
	{
		playerTurnManager.AnswerSelected(answer1Result);
	}
	public void OnAnswer2Button()
	{
		playerTurnManager.AnswerSelected(answer2Result);
	}
	public void OnAnswer3Button()
	{
		playerTurnManager.AnswerSelected(answer3Result);
	}
	public void OnAnswer4Button()
	{
		playerTurnManager.AnswerSelected(answer4Result);
	}
}
