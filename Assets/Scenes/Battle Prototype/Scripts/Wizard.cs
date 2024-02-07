using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
	void OnMouseEnter()
	// For hovering a wizard
	{
		// Get the UIHUD Manager
		UIHUDManager uiHudManager = FindObjectOfType<UIHUDManager>();

		// Show and wizard's stats
		uiHudManager.ShowWizardStats();
		uiHudManager.SetWizardStats(unitSO, currentHealth);
	}

	void OnMouseDown()
	// For selecting a wizard
	{
		// Check for if its player turn
		if (FindObjectOfType<BattleManager>().GetBattleState() == BattleState.PLAYER_TURN)
		{
            // Call the appropriate function in PlayerTurn
            PlayerTurnManager playerTurnManager = FindObjectOfType<PlayerTurnManager>();
            playerTurnManager.WizardSelected(this);
        }
	}
}
