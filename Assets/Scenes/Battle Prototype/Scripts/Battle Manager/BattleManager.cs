using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BattleState { START, PLAYER_TURN, ENEMY_TURN, WON, LOST }

public class BattleManager : MonoBehaviour
{
	[Header("Battle State Scripts")]
	[SerializeField] StartBattle startBattle;
	[SerializeField] PlayerTurn playerTurn;
	[SerializeField] EnemyTurn enemyTurn;
	[SerializeField] WonBattle wonBattle;
	[SerializeField] LostBattle lostBattle;

	[Header("UI")]
	public GameObject wizardStats;
	public GameObject enemyStats;
	public TextMeshProUGUI dialogueText;
	public GameObject timer;
	public GameObject answers;
	public GameObject abilitiesPanel;

	[Header("Wizards")]
	public GameObject wizardPrefab;
	public Unit wizardUnit;

	[Header("Enemies")]
	public GameObject enemyPrefab;
    public Unit enemyUnit;

    [Header("Slots")]
	// should be "Grids" instead?
	public Transform wizardSlot;
	public Transform enemySlot;

	BattleState battleState;

    void Start()
    {
		SetStart();
    }

	public void SetStart()
	{
		battleState = BattleState.START;
        StartCoroutine(startBattle.SetupBattle());
    }
	public void SetPlayerTurn()
	{
		battleState = BattleState.PLAYER_TURN;
		playerTurn.BecamePlayerTurn();
	}
	public void SetEnemyTurn()
	{
		battleState = BattleState.ENEMY_TURN;
		StartCoroutine(enemyTurn.BecameEnemyTurn());
	}
	public void SetWon()
	{
		battleState = BattleState.WON;
		wonBattle.BecameWon();
	}
	public void SetLost()
	{
		battleState = BattleState.LOST;
		lostBattle.BecameLost();
	}

	public BattleState GetBattleState()
	{
		return battleState;
	}
	public void SetBattleState(BattleState newBattleState)
	{
		battleState = newBattleState;
	}
}
