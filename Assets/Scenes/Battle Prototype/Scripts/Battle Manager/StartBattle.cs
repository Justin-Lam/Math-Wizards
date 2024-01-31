using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartBattle : MonoBehaviour
{
    [SerializeField] BattleManager2 battleManager;

    public IEnumerator SetupBattle()
    {
        // Set state
        battleManager.SetBattleState(BattleState.START);

        // Hide UI stuff
        battleManager.timer.SetActive(false);
        battleManager.answers.SetActive(false);
        battleManager.abilitiesPanel.SetActive(false);

        // Set dialogue
        battleManager.dialogueText.text = "BATTLE START !!!";

        // Spawn wizards
        GameObject wizardGO = Instantiate(battleManager.wizardPrefab, battleManager.wizardSlot);
        battleManager.wizardUnit = wizardGO.GetComponent<Unit>();

        // Spawn enemies
        GameObject enemyGO = Instantiate(battleManager.enemyPrefab, battleManager.enemySlot);
        battleManager.enemyUnit = enemyGO.GetComponent<Unit>();

        // Wait 2 seconds
        yield return new WaitForSeconds(2f);

        // Set to player turn
        battleManager.SetPlayerTurn();
    }
}
