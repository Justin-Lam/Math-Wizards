using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartBattle : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;
    [SerializeField] GameObject wizardPrefab;
    [SerializeField] GameObject enemyPrefab;

    public IEnumerator SetupBattle()
    {
        // Hide UI stuff
        battleManager.wizardStats.SetActive(false);
		battleManager.enemyStats.SetActive(false);
		battleManager.timer.SetActive(false);
        battleManager.answers.SetActive(false);
        battleManager.abilitiesPanel.SetActive(false);

        // Show UI stuff
        battleManager.dialoguePanel.SetActive(true);

        // Set dialogue
        battleManager.dialogueText.text = "BATTLE START !!!";

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

		// Wait 2 seconds
		yield return new WaitForSeconds(2f);

        // Set to player turn
        battleManager.SetPlayerTurn();
    }
}
