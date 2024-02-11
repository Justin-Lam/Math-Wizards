using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answers : MonoBehaviour
{
	[SerializeField][Tooltip("The wrong answers will be +- this number off of the answer")] int incorrectAnswerMaxDifference;
	int[] answerValues = new int[4];		public int[] AnswerValues => answerValues;
	bool[] answerResults = new bool[4];		public bool[] AnswerResults => answerResults;		// holds the result (right answer or wrong answer) for each answer button

	public void GenerateAnswers(int answer)
	{
		// Select a button to hold the correct answer
		int correctAnswerButtonNum = Random.Range(0, 4);

		// Add the correct answer to its appropriate spot in answerValues
		answerValues[correctAnswerButtonNum] = answer;

		// Set the results of the buttons
		for (int i = 0; i < 4; i++)
		{
			answerResults[i] = (i == correctAnswerButtonNum);
		}

		// Generate the incorrect answers, making sure they're unique
		HashSet<int> incorrectAnswersSet = new HashSet<int>();		// we use a set here because all elements in it must be unique
		while (incorrectAnswersSet.Count < 3)
		{
			// Get an incorrect answer that is unique from the correct answer
			int incorrectAnswer = answer + Random.Range(-incorrectAnswerMaxDifference, incorrectAnswerMaxDifference + 1);
			while ( incorrectAnswer == answer )
			{
				incorrectAnswer = answer + Random.Range(-incorrectAnswerMaxDifference, incorrectAnswerMaxDifference + 1);
			}

			// Attempt to add the incorrect answer to the set. If it's not unique from one of the incorrect answers already in the set, it'll get tossed
			incorrectAnswersSet.Add(incorrectAnswer);
		}

		// Add the incorrect answers to the empty spots in answerValues
		List<int> incorrectAnswersList = new List<int>(incorrectAnswersSet);		// we create a list from the set so we can use indexing

		for (int i = 0; i < 4; i++)
		{
			if (i == correctAnswerButtonNum)
			{
				continue;
			}
			else
			{
				answerValues[i] = incorrectAnswersList[0];
				incorrectAnswersList.RemoveAt(0);
			}
		}
	}
}
