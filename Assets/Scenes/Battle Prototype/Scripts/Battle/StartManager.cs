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
        foreach (WizardData wizardData in battleManager.battleData.wizards)
        {
			// Create the wizard
            Wizard wizard = Instantiate(wizardPrefab, wizardGrid.transform.GetChild(wizardData.slot - 1).transform).GetComponent<Wizard>();

			// Initialize the wizard
            wizard.Initialize(wizardData.wizard);

			// Add the wizard to the list of alive wizards
			battleManager.aliveWizards.Add(wizard);
        }

		// Spawn enemies
		foreach (EnemyData enemyData in battleManager.battleData.waves[0].enemies)
		{
			// Create the enemy
			Enemy enemy = Instantiate(enemyPrefab, enemyGrid.transform.GetChild(enemyData.slot - 1).transform).GetComponent<Enemy>();

			// Initialize the enemy
			enemy.Initialize(enemyData.enemy);

			// Add the enemy to the list of alive enemies
			battleManager.aliveEnemies.Add(enemy);
		}

        // Set to player turn
        battleManager.SetPlayerTurn();
    }
}
