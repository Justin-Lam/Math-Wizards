using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WizardInteract : MonoBehaviour
{
	BattleManager battleManager;
	PlayerTurnManager playerTurnManager;
	CameraPanAndZoom cameraPanAndZoom;
	Unit unit;

	void Start()
	{
		// Set variables
		battleManager = FindObjectOfType<BattleManager>();
		playerTurnManager = FindObjectOfType<PlayerTurnManager>();
		cameraPanAndZoom = FindObjectOfType<CameraPanAndZoom>();
		unit = gameObject.GetComponent<Unit>();
	}

	public void OnHovered()
	{
		// Show wizard's stats in HUD
		battleManager.ShowWizardStats();
		battleManager.SetWizardStats(unit);

		// Zoom the camera in on them if a wizard hasn't been selected or if an ability has been selected and it targets wizards
		if (playerTurnManager.SelectedWizard == null || playerTurnManager.SelectedAbilitySO != null && playerTurnManager.SelectedAbilitySO.TargetType == AbilitySO.Targets.WIZARD) { cameraPanAndZoom.SetUnitHovered(unit); }
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

				// Zoom the camera in on them
				cameraPanAndZoom.SetUnitSelected(unit);
			}
			// Case 2: Selecting a wizard as the target of an ability
			else if (playerTurnManager.SelectedAbilitySO != null && playerTurnManager.SelectedAbilitySO.TargetType == AbilitySO.Targets.WIZARD && playerTurnManager.SelectedTarget == null)
			{
				// Call the appropriate function in PlayerTurnManager
				playerTurnManager.SelectTarget(unit);
			}
		}
	}
}
