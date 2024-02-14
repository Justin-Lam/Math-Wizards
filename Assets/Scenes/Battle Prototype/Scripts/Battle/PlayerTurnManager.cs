using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
	delegate void ActivateAbilityDelegate(Unit user, Unit target, float mathResultMultiplier);

	[SerializeField] BattleManager battleManager;
	[SerializeField] UIHUDManager uiHudManager;
	[SerializeField] MathManager mathManager;

	Unit selectedWizard;									public Unit SelectedWizard => selectedWizard;
	AbilitySO selectedAbilitySO;							public AbilitySO SelectedAbilitySO => selectedAbilitySO;
	Unit selectedTarget;									public Unit SelectedTarget => selectedTarget;

	int actionsRemaining;

	public void SetupPlayerTurn()
	{
		// Initialize all selected variables to null
		selectedWizard = null;
		selectedAbilitySO = null;
		selectedTarget = null;

		// Set actionsRemaining
		actionsRemaining = 5;

		// Display actions remaining
		uiHudManager.SetActionsNumText(actionsRemaining.ToString());

		// Display "Select a wizard"
		uiHudManager.SetBattleText("Select a wizard");
    }

	public void WizardSelected(Unit wizard)
	{
		// Set selectedWizard
		selectedWizard = wizard;

		// Show abilities panel
		uiHudManager.ShowAbilitiesPanel();

		// Set ability buttons
		uiHudManager.SetAbilityButtons(wizard);

		// Display "Choose an ability"
		uiHudManager.SetBattleText("Choose an ability");
	}

	public void OnAbility1Selected() { AbilitySelected(0); }
	public void OnAbility2Selected() { AbilitySelected(1); }
	public void OnAbility3Selected() { AbilitySelected(2); }
	public void OnAbility4Selected() { AbilitySelected(3); }
	void AbilitySelected(int abiltyNum)
	{
		// Hide the abilities panel
		uiHudManager.HideAbilitiesPanel();

		// Set selectedAbilitySO
		selectedAbilitySO = selectedWizard.Abilities[abiltyNum];

		// Give a math exercise if the ability is untargeted
		if (selectedAbilitySO.TargetType == AbilitySO.Targets.NONE) { StartCoroutine(mathManager.GiveMathExercise()); }

		// Display "Pick a target" if the ability is targeted
		else { uiHudManager.SetBattleText("Pick a target"); }
	}

	public void TargetSelected(Unit target)
	{
		// Set selectedTarget
		selectedTarget = target;

		// Give a math exercise
		StartCoroutine(mathManager.GiveMathExercise());
	}

	public void ActivateAbility(float mathResultMultiplier)
	{
		// Activate the ability
		selectedAbilitySO.Activate(selectedWizard, selectedTarget, mathResultMultiplier);

		// Subtract an action
		subtractAction();
	}


	public void subtractAction()
	{
		// Reset all selected things
		selectedWizard = null;
		selectedAbilitySO = null;
		selectedTarget = null;

		// Subtract an action
		actionsRemaining--;

		// Display actions remaining
		uiHudManager.SetActionsNumText(actionsRemaining.ToString());

		// Display "Select a wizard"
		uiHudManager.SetBattleText("Select a wizard");

		// Set to enemy turn if there are 0 actions remaining
		if (actionsRemaining == 0) { StartCoroutine(WaitThenSetEnemyTurn()); }
		
		// Display "Select a wizard" if there are actions remaining
		else { uiHudManager.SetBattleText("Select a wizard"); }
	}

	IEnumerator WaitThenSetEnemyTurn()
	{
		// Set enemy turn after some time
		yield return new WaitForSeconds(2f);
		battleManager.SetEnemyTurn();
	}



	/*
	public void OnAttackButton()
    {
        // Record the ability
        action = "attack";

		// Hide abilities panel
		uiHudManager.HideAbilitiesPanel();

		// Start a math exercise
		StartCoroutine(mathManager.ExecuteMathExercise());
    }
    public void OnHealButton()
    {
        // Record the ability
        action = "heal";

		// Hide abilities panel
		uiHudManager.HideAbilitiesPanel();

		// Give a math question
		StartCoroutine(mathManager.ExecuteMathExercise());
	}

	public void AnswerSelected(bool result)
    {
		// Deactivate timer
		//uiHudManager.DeactivateTimer();

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
		// Set battle text
		uiHudManager.SetBattleText("Out of time");

		StartCoroutine(WaitThenSetEnemyTurn());
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


	*/
}
