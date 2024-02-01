using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnitStats : MonoBehaviour
{
	[SerializeField] GameObject wizardStats;
	[SerializeField] GameObject enemyStats;

	void OnMouseEnter()
	// For when anything is unhovered
	{
		// Hide stats UI
		wizardStats.SetActive(false);
		enemyStats.SetActive(false);
	}
}
