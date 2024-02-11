using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
	void OnMouseEnter()
	// Show enemy's stats in HUD
	{
		// Get the UIHUD Manager
		UIHUDManager uiHudManager = FindObjectOfType<UIHUDManager>();

		// Show and set enemy's stats
		uiHudManager.ShowEnemyStats();
		uiHudManager.SetEnemyStats(this);
	}
	void OnMouseExit()
	// Hide enemy's stats in HUD
	{
		// Get the UIHUD Manager
		UIHUDManager uiHudManager = FindObjectOfType<UIHUDManager>();

		// Hide enemy's stats
		uiHudManager.HideEnemyStats();
	}
	void OnMouseDown()
	// Select the enemy as the target of an ability
	{
		// Get BattleManager
		BattleManager battleManager = FindObjectOfType<BattleManager>();

		// Check that it's the player's turn
		if (battleManager.State == BattleManager.BattleState.PLAYER_TURN)
		{
			// Get PlayerTurnManager
			PlayerTurnManager playerTurnManager = FindObjectOfType<PlayerTurnManager>();

			// Select the enemy as the target of an ability
			if (playerTurnManager.SelectedWizard != null && playerTurnManager.SelectedTarget == null && playerTurnManager.SelectedAbilitySO.TargetType == AbilitySO.Targets.ENEMY)
			{
				// Call the appropriate function in PlayerTurnManager
				playerTurnManager.TargetSelected(this);
			}
		}
	}
}
