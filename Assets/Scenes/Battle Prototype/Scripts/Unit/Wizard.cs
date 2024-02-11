using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BattleManager;

public class Wizard : Unit
{
	void OnMouseEnter()
	// Show wizard's stats in HUD
	{
		// Get the UIHUD Manager
		UIHUDManager uiHudManager = FindObjectOfType<UIHUDManager>();

		// Show and set wizard's stats
		uiHudManager.ShowWizardStats();
		uiHudManager.SetWizardStats(this);
	}
	void OnMouseExit()
	// Hide wizard's stats in HUD
	{
		// Get the UIHUD Manager
		UIHUDManager uiHudManager = FindObjectOfType<UIHUDManager>();

		// Hide wizard's stats
		uiHudManager.HideWizardStats();
	}
	void OnMouseDown()
	// Select the wizard either for using one of their abilities or as the target of an ability
	{
		// Get BattleManager
		BattleManager battleManager = FindObjectOfType<BattleManager>();

		// Check that it's the player's turn
		if (battleManager.State == BattleManager.BattleState.PLAYER_TURN)
		{
			// Get PlayerTurnManager
			PlayerTurnManager playerTurnManager = FindObjectOfType<PlayerTurnManager>();

			// Case 1: Selecting a wizard to use an ability
			if (playerTurnManager.SelectedWizard == null)
			{
				// Call the appropriate function in PlayerTurnManager
				playerTurnManager.WizardSelected(this);
			}

			// Case 2: Selecting a wizard as the target of an ability
			else if (playerTurnManager.SelectedTarget == null && playerTurnManager.SelectedAbilitySO.TargetType == AbilitySO.Targets.WIZARD)
			{
				// Call the appropriate function in PlayerTurnManager
				playerTurnManager.TargetSelected(this);
			}
		}
	}
}
