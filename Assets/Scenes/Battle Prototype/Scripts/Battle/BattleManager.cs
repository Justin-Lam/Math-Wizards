using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BattleManager : MonoBehaviour
{
	public enum BattleState { START, PLAYER_TURN, ENEMY_TURN, WON, LOST }

	[Header("Battle Data")]
	public BattleData battleData;

	[Header("Battle State Scripts")]
	[SerializeField] StartManager startManager;
	[SerializeField] PlayerTurnManager playerTurnManager;
	[SerializeField] EnemyTurnManager enemyTurnManager;
	[SerializeField] WonManager wonManager;
	[SerializeField] LostManager lostManager;

	[Header("Game Objects")]
	[SerializeField] GameObject wizardStatsGO;
	[SerializeField] GameObject enemyStatsGO;
	[SerializeField] GameObject abilitiesPanelGO;

	[Header("Components")]
	[SerializeField] TextMeshProUGUI actionsNumText;
	[SerializeField] TextMeshProUGUI battleText;
	[SerializeField] UnitStats wizardStats;
	[SerializeField] UnitStats enemyStats;
	[SerializeField] AbilityButtons abilityButtons;

	BattleState state;		public BattleState State => state;

    void Start()
    {
		SetStart();
    }

	public void SetStart()
	{
		state = BattleState.START;
		startManager.SetupBattle();
	}
	public void SetPlayerTurn()
	{
		state = BattleState.PLAYER_TURN;
		playerTurnManager.SetupPlayerTurn();
	}
	public void SetEnemyTurn()
	{
		state = BattleState.ENEMY_TURN;
		StartCoroutine(enemyTurnManager.SetupEnemyTurn());
	}
	public void SetWon()
	{
		state = BattleState.WON;
		wonManager.SetupWon();
	}
	public void SetLost()
	{
		state = BattleState.LOST;
		lostManager.SetupLost();
	}

	public void ShowWizardStats() { wizardStatsGO.SetActive(true); }
	public void HideWizardStats() { wizardStatsGO.SetActive(false); }
	public void ShowEnemyStats() { enemyStatsGO.SetActive(true); }
	public void HideEnemyStats() { enemyStatsGO.SetActive(false); }
	public void ShowAbilitiesPanel() { abilitiesPanelGO.SetActive(true); }
	public void HideAbilitiesPanel() { abilitiesPanelGO.SetActive(false); }

	public void SetActionsNumText(string text) { actionsNumText.text = text; }
	public void SetBattleText(string text) { battleText.text = text; }
	public void SetWizardStats(Unit unit) { wizardStats.UpdateDisplay(unit); }
	public void SetEnemyStats(Unit unit) { enemyStats.UpdateDisplay(unit); }
	public void SetAbilityButtons(Unit wizard) { abilityButtons.SetButtons(wizard); }
}
