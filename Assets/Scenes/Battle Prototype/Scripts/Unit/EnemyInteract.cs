using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyInteract : MonoBehaviour
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
	// Show enemy's stats in HUD
	{
		battleManager.ShowEnemyStats();
		battleManager.SetEnemyStats(unit);
	}

	public void OnClicked()
	// Select the enemy as the target of an ability
	{
		// Check that it's the player's turn
		if (battleManager.State == BattleManager.BattleState.PLAYER_TURN)
		{
			// Select the enemy as the target of an ability
			if (playerTurnManager.SelectedWizard != null && playerTurnManager.SelectedAbilitySO != null && playerTurnManager.SelectedAbilitySO.TargetType == AbilitySO.Targets.ENEMY && playerTurnManager.SelectedTarget == null)
			{
				// Call the appropriate function in PlayerTurnManager
				playerTurnManager.SelectTarget(unit);
			}
		}
	}
}
