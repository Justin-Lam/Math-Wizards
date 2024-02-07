using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;
	[SerializeField] UIHUDManager uiHudManager;

	public IEnumerator SetupEnemyTurn()
    {
		// Set dialogue
		uiHudManager.SetBattleText("Enemies' Turn");

		// Wait for some time, attach the wizard, then wait again
		yield return new WaitForSeconds(1f);
		//battleManager.wizardUnit.TakeDamage(battleManager.enemyUnit.GetUnitSO().physicalAttack);
		// update wizard hp in hud
		yield return new WaitForSeconds(1f);

		// Change battle state depending on status of the wizard
		if (true)//battleManager.wizardUnit.IsAlive())
		{
			battleManager.SetPlayerTurn();
		}
		else
		{
			battleManager.SetLost();
		}
	}
}
