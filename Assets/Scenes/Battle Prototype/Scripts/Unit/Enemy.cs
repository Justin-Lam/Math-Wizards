using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
	BattleManager battleManager;
	PlayerTurnManager playerTurnManager;

	void Start()
	{
		battleManager = FindObjectOfType<BattleManager>();
		playerTurnManager = FindObjectOfType<PlayerTurnManager>();
	}

	void OnMouseEnter()
	// Show enemy's stats in HUD
	{
		// Show and set enemy's stats
		battleManager.ShowEnemyStats();
		battleManager.SetEnemyStats(this);
	}
	void OnMouseExit()
	// Hide enemy's stats in HUD
	{
		// Hide enemy's stats
		battleManager.HideEnemyStats();
	}
	void OnMouseDown()
	// Select the enemy as the target of an ability
	{
		// Check that it's the player's turn
		if (battleManager.State == BattleManager.BattleState.PLAYER_TURN)
		{
			// Select the enemy as the target of an ability
			if (playerTurnManager.SelectedWizard != null && playerTurnManager.SelectedTarget == null && playerTurnManager.SelectedAbilitySO.TargetType == AbilitySO.Targets.ENEMY)
			{
				// Call the appropriate function in PlayerTurnManager
				playerTurnManager.TargetSelected(this);
			}
		}
	}
}
