using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("num seconds timer runs for")][SerializeField] float timeLimit;
    float timeLeft;
    [SerializeField] Slider leftTimer;
    [SerializeField] Slider rightTimer;

    IEnumerator ActivateTimer()
    {
        timeLeft = timeLimit;

        while (timeLeft > 0)
        {
            leftTimer.value = timeLeft / timeLimit;
            rightTimer.value = timeLeft / timeLimit;

            yield return null;		// wait for the next frame

            timeLeft -= Time.deltaTime;
        }

        // OutOfTime();
    }
}

/*
public class Timer : MonoBehaviour
{
	[Tooltip("num seconds timer runs for")][SerializeField] float timeLimit;
	float timeLeft;
	[SerializeField] Slider leftTimer;
    [SerializeField] Slider rightTimer;

	void Start()
	{
		timeLeft = timeLimit;
	}

	void Update()
	{
		if (gameObject.activeSelf)     // timer is showing
		{
			// if(timeLeft <= 0)
				// out of time function

			timeLeft -= 1 * Time.deltaTime;
			leftTimer.value = timeLeft / timeLimit;
			rightTimer.value = timeLeft / timeLimit;
		}
		else
		{
			timeLeft = timeLimit;
		}
	}
}
*/
