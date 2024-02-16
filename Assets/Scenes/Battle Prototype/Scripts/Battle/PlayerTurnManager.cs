using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
	delegate void ActivateAbilityDelegate(Unit user, Unit target, float mathResultMultiplier);

	[SerializeField] BattleManager battleManager;
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
		battleManager.SetActionsNumText(actionsRemaining.ToString());

		// Display "Select a wizard"
		battleManager.SetBattleText("Select a wizard");
    }

	public void WizardSelected(Unit wizard)
	{
		// Set selectedWizard
		selectedWizard = wizard;

		// Show abilities panel
		battleManager.ShowAbilitiesPanel();

		// Set ability buttons
		battleManager.SetAbilityButtons(wizard);

		// Display "Choose an ability"
		battleManager.SetBattleText("Choose an ability");
	}

	public void OnAbility1Selected() { AbilitySelected(0); }
	public void OnAbility2Selected() { AbilitySelected(1); }
	public void OnAbility3Selected() { AbilitySelected(2); }
	public void OnAbility4Selected() { AbilitySelected(3); }
	void AbilitySelected(int abiltyNum)
	{
		// Hide the abilities panel
		battleManager.HideAbilitiesPanel();

		// Set selectedAbilitySO
		selectedAbilitySO = selectedWizard.Abilities[abiltyNum];

		// Give a math exercise if the ability is untargeted
		if (selectedAbilitySO.TargetType == AbilitySO.Targets.NONE) { StartCoroutine(mathManager.GiveMathExercise()); }

		// Display "Pick a target" if the ability is targeted
		else { battleManager.SetBattleText("Pick a target"); }
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
		battleManager.SetActionsNumText(actionsRemaining.ToString());

		// Display "Select a wizard"
		battleManager.SetBattleText("Select a wizard");

		// Set to enemy turn if there are 0 actions remaining
		if (actionsRemaining == 0) { StartCoroutine(WaitThenSetEnemyTurn()); }
		
		// Display "Select a wizard" if there are actions remaining
		else { battleManager.SetBattleText("Select a wizard"); }
	}

	IEnumerator WaitThenSetEnemyTurn()
	{
		// Set enemy turn after some time
		yield return new WaitForSeconds(2f);
		battleManager.SetEnemyTurn();
	}
}
