using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
	void OnMouseEnter()
	// For hovering a wizard
	{
		// Get the Wizard Stats game object and its UnitStats
		GameObject wizardStatsGO = FindObjectOfType<BattleManager>().wizardStats;
		UnitStats unitStats = wizardStatsGO.GetComponent<UnitStats>();

		// Show and update unit stats
		wizardStatsGO.SetActive(true);
		unitStats.UpdateDisplay(GetUnitSO(), GetCurrentHealth());
	}

	void OnMouseDown()
	// For selecting a wizard
	{
		// Check for if its player turn
		if (FindObjectOfType<BattleManager>().GetBattleState() == BattleState.PLAYER_TURN &&
			FindObjectOfType<PlayerTurn>().GetWizardSelected() == null)
		{
            // Call the appropriate function in PlayerTurn
            PlayerTurn playerTurn = FindObjectOfType<PlayerTurn>();
            playerTurn.WizardSelected(this);
        }
	}
}
