using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WizardInteract : MonoBehaviour
{
	BattleManager battleManager;
	PlayerTurnManager playerTurnManager;
	Unit unit;

	void Start()
	{
		battleManager = FindObjectOfType<BattleManager>();
		playerTurnManager = FindObjectOfType<PlayerTurnManager>();
		unit = this.gameObject.GetComponent<Unit>();
	}

	public void OnHovered()
	// Show wizard's stats in HUD
	{
		battleManager.ShowWizardStats();
		battleManager.SetWizardStats(unit);
	}

	public void OnClicked()
	// Select the wizard either for using one of their abilities or as the target of an ability
	{
		// Check that it's the player's turn
		if (battleManager.State == BattleManager.BattleState.PLAYER_TURN)
		{
			// Case 1: Selecting a wizard to use an ability
			if (playerTurnManager.SelectedWizard == null)
			{
				// Call the appropriate function in PlayerTurnManager
				playerTurnManager.SelectWizard(unit);
			}
			// Case 2: Selecting a wizard as the target of an ability
			else if (playerTurnManager.SelectedTarget == null && playerTurnManager.SelectedAbilitySO.TargetType == AbilitySO.Targets.WIZARD)
			{
				// Call the appropriate function in PlayerTurnManager
				playerTurnManager.SelectWizard(unit);
			}
		}
	}
}
