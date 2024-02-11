using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] MathManager mathManager;
	[SerializeField] Slider leftTimer;
	[SerializeField] Slider rightTimer;

	[SerializeField][Tooltip("Number of seconds timer runs for")] float timeLimit;
    float timeLeft;
	bool isActive;

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
		isActive = false;
	}
}