using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartManager : MonoBehaviour
{
	[Header("Managers")]
	[SerializeField] BattleManager battleManager;
    [SerializeField] MathManager mathManager;

	[Header("Prefabs")]
	[SerializeField] GameObject wizardPrefab;
    [SerializeField] GameObject enemyPrefab;

    [Header("Grids")]
    [SerializeField] GameObject wizardGrid;
	[SerializeField] GameObject enemyGrid;

	public void SetupBattle()
    {
		// Hide UI and HUD stuff
		battleManager.HideWizardStats();
		battleManager.HideEnemyStats();
		battleManager.HideAbilitiesPanel();
        mathManager.HideMathCanvas();

        // Spawn wizards
        foreach (UnitData unitData in battleManager.battleData.wizards)
        {
			// Create the wizard
            Unit wizard = Instantiate(wizardPrefab, wizardGrid.transform.GetChild(unitData.slot - 1).transform).GetComponent<Unit>();

			// Initialize the wizard
            wizard.InitializeUnit(unitData.unit, false);

			// Add the wizard to the list of alive wizards
			battleManager.aliveWizards.Add(wizard);
        }

		// Spawn enemies
		foreach (UnitData unitData in battleManager.battleData.waves[0].enemies)
		{
			// Create the enemy
			Unit enemy = Instantiate(enemyPrefab, enemyGrid.transform.GetChild(unitData.slot - 1).transform).GetComponent<Unit>();

			// Initialize the enemy
			enemy.InitializeUnit(unitData.unit, true);

			// Add the enemy to the list of alive enemies
			battleManager.aliveEnemies.Add(enemy);
		}

        // Set to player turn
        battleManager.SetPlayerTurn();
    }
}
