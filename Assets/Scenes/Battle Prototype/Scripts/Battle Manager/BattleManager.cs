using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYER_TURN, ENEMY_TURN, WON, LOST }

public class BattleManager : MonoBehaviour
{
	[Header("Battle Data")]
	public BattleData battleData;

	[Header("Battle State Scripts")]
	[SerializeField] StartManager startManager;
	[SerializeField] PlayerTurnManager playerTurnManager;
	[SerializeField] EnemyTurnManager enemyTurnManager;
	[SerializeField] WonManager wonManager;
	[SerializeField] LostManager lostManager;

	BattleState battleState;

    void Start()
    {
		SetStart();
    }

	public void SetStart()
	{
		battleState = BattleState.START;
		startManager.SetupBattle();
	}
	public void SetPlayerTurn()
	{
		battleState = BattleState.PLAYER_TURN;
		playerTurnManager.SetupPlayerTurn();
	}
	public void SetEnemyTurn()
	{
		battleState = BattleState.ENEMY_TURN;
		StartCoroutine(enemyTurnManager.SetupEnemyTurn());
	}
	public void SetWon()
	{
		battleState = BattleState.WON;
		wonManager.SetupWon();
	}
	public void SetLost()
	{
		battleState = BattleState.LOST;
		lostManager.SetupLost();
	}

	public BattleState GetBattleState()
	{
		return battleState;
	}
}
