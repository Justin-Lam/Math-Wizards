using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("num seconds timer runs for")][SerializeField] float timeLimit;
    float timeLeft;
	bool active;
    [SerializeField] Slider leftTimer;
    [SerializeField] Slider rightTimer;
	[SerializeField] PlayerTurn playerTurn;

    public IEnumerator ActivateTimer()
    {
        timeLeft = timeLimit;
		active = true;

        while (timeLeft > 0 && active)
        {
            leftTimer.value = timeLeft / timeLimit;
            rightTimer.value = timeLeft / timeLimit;

            yield return null;		// wait for the next frame

            timeLeft -= Time.deltaTime;
        }

		if (active)		// ran out of time
		{
			active = false;
			playerTurn.OutOfTime();
        }
    }

	public void DeactivateTimer()
	{
		active = false;
	}
}