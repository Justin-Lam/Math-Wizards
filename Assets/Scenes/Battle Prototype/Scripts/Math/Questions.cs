using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Questions : MonoBehaviour
{
	[SerializeField][Tooltip("Numbers x and y composing the math question will have values between +- this number, inclusive")] int numberRange;

	int x;					public int X => x;
	int y;					public int Y => y;
	char mathOperator;		public char MathOperator => mathOperator;
	int answer;				public int Answer => answer;

	public void GenerateQuestion()
	{
		// Choose a question type and then generate it
		switch (Random.Range(0, 1))     // change to (0, 4) when adding more question types
		{
			case 0:
				mathOperator = '+';
				GenerateAdditionQuestion();
				break;

			case 1:
				break;

			case 2:
				break;

			case 3:
				break;

			default:
				Debug.Log("ERROR: default switch case activated in GenerateQuestion() of Questions");
				break;
		}
	}

	void GenerateAdditionQuestion()
	{
		// Generate the question and answer
		x = Random.Range(-numberRange, numberRange + 1);
		y = Random.Range(-numberRange, numberRange + 1);
		answer = x + y;
	}
}
