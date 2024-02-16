using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;

	public IEnumerator SetupEnemyTurn()
    {
		battleManager.SetBattleText("Enemies' Turn");
		yield return null;
	}
}
