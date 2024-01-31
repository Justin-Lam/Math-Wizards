using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
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
