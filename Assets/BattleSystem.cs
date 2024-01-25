using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
	public GameObject wizardPrefab;
	public GameObject enemyPrefab;

	public Transform wizardSlot;
	public Transform enemySlot;

	public BattleState state;

	void Start()
	{
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{
		// Spawn wizards
		Instantiate(wizardPrefab, wizardSlot);

		// Spawn enemies
		Instantiate(enemyPrefab, enemySlot);

		// Set to player turn
		yield return new WaitForSeconds(2f);
		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	void PlayerTurn()
	{

	}
}
