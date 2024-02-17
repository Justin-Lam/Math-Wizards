using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;

	EnemyAISO aiSO;
	AbilitySO selectedAbilitySO;
	Unit selectedTarget;

	public void SetupEnemyTurn()
	{
		// Set battle text
		battleManager.SetBattleText("Enemies' Turn");

		// Make all alive enemies take an action
		StartCoroutine(ExecuteActions());
	}

	IEnumerator ExecuteActions()
	{
		// Wait for some time before doing the enemies' actions
		yield return new WaitForSeconds(2f);

		// One by one, let each enemy take an action
		foreach (Unit enemy in battleManager.aliveEnemies)
		{
			// Reset all selected things
			aiSO = null;
			selectedAbilitySO = null;
			selectedTarget = null;

			// Clear battle text
			battleManager.SetBattleText("");

			// Wait for just a blip
			yield return new WaitForSeconds(0.1f);

			// Get the enemy's AI
			aiSO = enemy.AISO;

			// Get the ability
			selectedAbilitySO = aiSO.GetAbilitySO();

			// Enemy's ability is untargeted
			if (selectedAbilitySO.TargetType == AbilitySO.Targets.NONE)
			{
				// Set battle text
				battleManager.SetBattleText($"{enemy.Name} uses {selectedAbilitySO.Name}");

				// Activate the ability
				selectedAbilitySO.Activate();
			}
			// Enemy's ability is targeted
			else
			{
				// Get the target
				selectedTarget = aiSO.GetTarget(battleManager.aliveWizards);

				// Set battle text
				battleManager.SetBattleText($"{enemy.Name} uses {selectedAbilitySO.Name} on {selectedTarget.Name}");

				// Activate the ability
				selectedAbilitySO.Activate(selectedTarget);
			}

			// Kill any enemies that died (kill = remove from list and hide)
			List<Unit> deadWizards = battleManager.aliveWizards.FindAll(wizard => wizard.CurrentHealth <= 0);			// save the wizards that died so we can hide them later
			battleManager.aliveWizards.RemoveAll(wizard => wizard.CurrentHealth <= 0);									// remove
			foreach (Unit wizard in deadWizards) { wizard.gameObject.SetActive(false); }								// hide
			
			// Wait for some time
			yield return new WaitForSeconds(1f);

			// Check if all wizards have died
			if (battleManager.aliveWizards.Count <= 0) { Debug.Log("breaking"); break; }
		}

		// Wait for some time
		yield return new WaitForSeconds(1f);

		// End of enemy turn
		// Change battle state depending on the state of the wizards
		if (battleManager.aliveWizards.Count > 0)		// there are wizards alive, set to player turn
		{
			battleManager.SetPlayerTurn();
		}
		else											// all wizards have died, set to lost
		{
			battleManager.SetLost();
		}
	}
}
