using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundInteract : MonoBehaviour
{
	BattleManager battleManager;
	PlayerTurnManager playerTurnManager;
	CameraPanAndZoom cameraPanAndZoom;

	void Start()
	{
		// Set variables
		battleManager = FindObjectOfType<BattleManager>();
		playerTurnManager = FindObjectOfType<PlayerTurnManager>();
		cameraPanAndZoom = FindObjectOfType<CameraPanAndZoom>();
	}

	public void OnHovered()
	{
		// Hide wizard stats and enemy stats in HUD
		battleManager.HideWizardStats();
		battleManager.HideEnemyStats();

		// Reset the camera zoom if a wizard hasn't been selected
		if (playerTurnManager.SelectedWizard == null) { cameraPanAndZoom.SetDefault(); }
	}

	public void OnClicked()
	// Unselect a wizard or unselect a wizard's ability
	{
		// Check that it's the player's turn
		if (battleManager.State == BattleManager.BattleState.PLAYER_TURN)
		{
			// Unselect a wizard's ability
			if (playerTurnManager.SelectedAbilitySO != null)        // a wizard and an ability have been selected
			{
				// Unselect the selected ability
				playerTurnManager.UnselectAbility();
			}
			else if (playerTurnManager.SelectedWizard != null)      // a wizard has been selected
			{
				// Unselect the selected wizard
				playerTurnManager.UnselectWizard();

				// Reset the camera zoom
				cameraPanAndZoom.SetDefault();
			}
		}
	}
}
