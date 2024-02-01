using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
	void OnMouseEnter()
	// For hovering an enemy
	{
		// Get the Enemy Stats game object and its UnitStats
		GameObject enemyStatsGO = FindObjectOfType<BattleManager>().enemyStats;
		UnitStats unitStats = enemyStatsGO.GetComponent<UnitStats>();

		// Show and update unit stats
		enemyStatsGO.SetActive(true);
		unitStats.UpdateDisplay(GetUnitSO(), GetCurrentHealth());
	}
}
