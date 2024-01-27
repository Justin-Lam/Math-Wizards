using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answers : MonoBehaviour
{
	[SerializeField] int wrongAnswerMaxDifference;

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
				answer.GetComponent<AnswerResult>().result = true;
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
                answer.GetComponent<AnswerResult>().result = false;
            }
		}
	}
}
