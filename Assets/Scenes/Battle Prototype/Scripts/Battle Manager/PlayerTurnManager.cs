using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;
	[SerializeField] UIHUDManager uiHudManager;
    [SerializeField] Questions questions;

    string action;

	public void SetupPlayerTurn()
	{
		// Set battle text
		uiHudManager.SetBattleText("5 Actions Remaining");
    }

	public void WizardSelected(Wizard wizard)
	{
		// Show abilities panel
		uiHudManager.ShowAbilitiesPanel();
	}

    public void OnAttackButton()
    {
        // Record the ability
        action = "attack";

		// Hide abilities panel
		uiHudManager.HideAbilitiesPanel();

		// Give a math question
		StartCoroutine(questions.GiveMathQuestion());
    }
    public void OnHealButton()
    {
        // Record the ability
        action = "heal";

		// Hide abilities panel
		uiHudManager.HideAbilitiesPanel();

		// Give a math question
		StartCoroutine(questions.GiveMathQuestion());
	}

	public void AnswerSelected(bool result)
    {
		// Deactivate timer
		uiHudManager.DeactivateTimer();

		// Hide math canvas
		uiHudManager.HideMathCanvas();

		if (result)
		{
			if (action == "attack")
				StartCoroutine(PlayerAttack());
			else if (action == "heal")
				StartCoroutine(PlayerHeal());
		}
		else
		{
			StartCoroutine(WrongAnswer());
		}
	}

	public void OutOfTime()
	{
		// Hide math canvas
		uiHudManager.HideMathCanvas();

		// Set battle text
		uiHudManager.SetBattleText("Out of time");

		StartCoroutine(WaitThenSetEnemyTurn());
	}
	IEnumerator WaitThenSetEnemyTurn()
	{
		// Set enemy turn after some time
		yield return new WaitForSeconds(2f);
		battleManager.SetEnemyTurn();
	}

	IEnumerator WrongAnswer()
	{
		// Set dialogue text
		uiHudManager.SetBattleText("Wrong answer");

		// Set enemy turn after some time
		yield return new WaitForSeconds(2f);
		battleManager.SetEnemyTurn();
	}

	IEnumerator PlayerAttack()
	{
		// Damage the enemy
		//battleManager.enemyUnit.TakeDamage(battleManager.wizardUnit.GetUnitSO().physicalAttack);

		// Set battle text
		uiHudManager.SetBattleText("Great mathing!");

		// Wait for some time
		yield return new WaitForSeconds(2f);

		// Change battle state depending on status of the enemy
		if (true)//battleManager.enemyUnit.IsAlive())
		{
			battleManager.SetEnemyTurn();
		}
		else
		{
			battleManager.SetWon();
		}
	}

	IEnumerator PlayerHeal()
	{
		// Heal the wizard a random amount
		//battleManager.wizardUnit.Heal(Random.Range(5, 15));

		// Set battle text
		uiHudManager.SetBattleText("Great mathing!");

		// Set enemy turn after some time
		yield return new WaitForSeconds(2f);
		battleManager.SetEnemyTurn();
	}
}
