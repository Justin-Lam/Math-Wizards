using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;
	[SerializeField] UIHUDManager uiHudManager;
	[SerializeField] GameObject wizardPrefab;
    [SerializeField] GameObject enemyPrefab;

    public void SetupBattle()
    {
        // Hide UI and HUD stuff
        uiHudManager.HideWizardStats();
        uiHudManager.HideEnemyStats();
        uiHudManager.HideAbilitiesPanel();
        uiHudManager.HideMathCanvas();

        // Spawn wizards
        foreach (UnitData unitData in battleManager.battleData.wizards)
        {
            Wizard wizard = Instantiate(wizardPrefab, unitData.slot.transform).GetComponent<Wizard>();
            wizard.SetUnitSO(unitData.unit);
            wizard.InitializeUnit();
        }

		// Spawn enemies
		foreach (UnitData unitData in battleManager.battleData.waves[0].enemies)
		{
			Unit enemy = Instantiate(enemyPrefab, unitData.slot.transform).GetComponent<Unit>();
			enemy.SetUnitSO(unitData.unit);
			enemy.InitializeUnit();
		}

        // Set to player turn
        battleManager.SetPlayerTurn();
    }
}
