using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
	void OnMouseEnter()
	// For hovering an enemy
	{
		// Get the UIHUD Manager
		UIHUDManager uiHudManager = FindObjectOfType<UIHUDManager>();

		// Show and wizard's stats
		uiHudManager.ShowEnemyStats();
		uiHudManager.SetEnemyStats(unitSO, currentHealth);
	}
}
