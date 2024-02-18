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
	[SerializeField] GameObject wizardStatsGO;			public void ShowWizardStats() { wizardStatsGO.SetActive(true); }			public void HideWizardStats() { wizardStatsGO.SetActive(false); }
	[SerializeField] GameObject enemyStatsGO;			public void ShowEnemyStats() { enemyStatsGO.SetActive(true); }				public void HideEnemyStats() { enemyStatsGO.SetActive(false); }
	[SerializeField] GameObject abilitiesPanelGO;		public void ShowAbilitiesPanel() { abilitiesPanelGO.SetActive(true); }		public void HideAbilitiesPanel() { abilitiesPanelGO.SetActive(false); }

	[Header("Components")]
	[SerializeField] TextMeshProUGUI actionsNumText;		public void SetActionsNumText(string text) { actionsNumText.text = text; }
	[SerializeField] TextMeshProUGUI battleText;			public void SetBattleText(string text) { battleText.text = text; }
	[SerializeField] UnitStats wizardStats;					public void SetWizardStats(Unit unit) { wizardStats.UpdateDisplay(unit); }
	[SerializeField] UnitStats enemyStats;					public void SetEnemyStats(Unit unit) { enemyStats.UpdateDisplay(unit); }
	[SerializeField] AbilityButtons abilityButtons;			public void SetAbilityButtons(Unit wizard) { abilityButtons.SetButtons(wizard); }


	public List<Unit> aliveWizards;
	public List<Unit> aliveEnemies; 
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
}
