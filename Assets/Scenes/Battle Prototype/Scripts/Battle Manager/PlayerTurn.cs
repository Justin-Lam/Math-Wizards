using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;
    [SerializeField] Questions questions;

	Wizard wizardSelected;
	// Ability abilitySelected;
	Unit enemySelected;

    string action;

	public void BecamePlayerTurn()
	{
		// Set dialogue
        battleManager.dialogueText.text = "Select a wizard";
    }

	public void WizardSelected(Wizard wizard)
	{
		// Set wizardSelected
		wizardSelected = wizard;
		wizardSelected = null;		// this is for temporary, this is ideally supposed to be in a different function as an ability wraps up

		// Show abilities panel
		battleManager.abilitiesPanel.SetActive(true);

		// Set dialogue 
		battleManager.dialogueText.text = "Choose an ability";
	}

    public void OnAttackButton()
    {
        // Record the ability
        action = "attack";

        // Hide abilities panel
        battleManager.abilitiesPanel.SetActive(false);

		// Give a math question
		questions.GiveMathQuestion();
    }
    public void OnHealButton()
    {
        // Record the ability
        action = "heal";

        // Hide abilities panel
        battleManager.abilitiesPanel.SetActive(false);

		// Give a math question
		questions.GiveMathQuestion();
	}

    public void AnswerSelected(bool result)
    {
		// Deactivate timer
		battleManager.timer.GetComponent<Timer>().DeactivateTimer();

		// Hide timer and answers
		battleManager.timer.SetActive(false);
		battleManager.answers.SetActive(false);

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
		// Hide timer and answers
		battleManager.timer.SetActive(false);
		battleManager.answers.SetActive(false);

		// Set dialogue text
		battleManager.dialogueText.text = "Out of time";

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
		battleManager.dialogueText.text = "Wrong answer";

		// Set enemy turn after some time
		yield return new WaitForSeconds(2f);
		battleManager.SetEnemyTurn();
	}

	IEnumerator PlayerAttack()
	{
		// Damage the enemy
		battleManager.enemyUnit.TakeDamage(battleManager.wizardUnit.GetUnitSO().physicalAttack);
		battleManager.dialogueText.text = "Great mathing!";

		// Wait for some time
		yield return new WaitForSeconds(2f);

		// Change battle state depending on status of the enemy
		if (battleManager.enemyUnit.IsAlive())
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
		battleManager.wizardUnit.Heal(Random.Range(5, 15));
		battleManager.dialogueText.text = "Great mathing!";

		// Set enemy turn after some time
		yield return new WaitForSeconds(2f);
		battleManager.SetEnemyTurn();
	}


	public Wizard GetWizardSelected()
	{
		return wizardSelected;
	}
	/*
	public Ability GetAbilitySelected()
	{
		return abilitySelected;
	}
	*/
	public Unit GetEnemySelected()
	{
		return enemySelected;
	}
}
