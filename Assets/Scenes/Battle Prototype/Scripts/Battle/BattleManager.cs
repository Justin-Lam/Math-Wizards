using System.Collections;
using System.Collections.Generic;
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
