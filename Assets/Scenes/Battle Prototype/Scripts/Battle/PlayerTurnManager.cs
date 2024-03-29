using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;
	[SerializeField] MathManager mathManager;
	[SerializeField] CameraPanAndZoom cameraPanAndZoom;

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

	public void SelectWizard(Unit wizard)
	{
		// Set selectedWizard
		selectedWizard = wizard;

		// Show abilities panel
		battleManager.ShowAbilitiesButtonsAndDescriptionPanel();

		// Set ability buttons
		battleManager.SetupAbilityButtonsAndDescriptionPanel(wizard);

		// Display "Choose an ability"
		battleManager.SetBattleText("Choose an ability");

		// Hide every other wizard
		foreach (Wizard otherWizard in battleManager.aliveWizards)
		{
			// Check that the wizard we're going to hide isn't the wizard that was selected
			if (otherWizard == selectedWizard) { continue; }
			else { otherWizard.gameObject.SetActive(false); }
		}
	}
	public void UnselectWizard()
	{
		// Unselect selected wizard
		selectedWizard = null;

		// Hide abilities panel
		battleManager.HideAbilityButtonsAndDescriptionPanel();

		// Display "Select a wizard"
		battleManager.SetBattleText("Select a wizard");

		// Show every other wizard
		foreach (Wizard wizard in battleManager.aliveWizards) { wizard.gameObject.SetActive(true); }
	}

	public void OnAbility1Selected() { SelectAbility(0); }
	public void OnAbility2Selected() { SelectAbility(1); }
	public void OnAbility3Selected() { SelectAbility(2); }
	public void OnAbility4Selected() { SelectAbility(3); }
	void SelectAbility(int abiltyNum)
	{
		// Hide the abilities panel
		battleManager.HideAbilityButtonsAndDescriptionPanel();

		// Zoom out the camera
		cameraPanAndZoom.SetDefault();

		// Set selectedAbilitySO
		selectedAbilitySO = selectedWizard.Abilities[abiltyNum];

		// Give a math exercise if the ability is untargeted
		if (selectedAbilitySO.TargetType == AbilitySO.Targets.NONE)
		{
			// Clear the battle text
			battleManager.SetBattleText("");

			// Give a math exercise
			StartCoroutine(mathManager.GiveMathExercise());	
		}

		// Display "Pick a target" if the ability is targeted
		else { battleManager.SetBattleText("Pick a target"); }

		// Show every other wizard
		foreach (Wizard wizard in battleManager.aliveWizards) { wizard.gameObject.SetActive(true); }
	}
	public void UnselectAbility()
	{
		// Unselect selected ability
		selectedAbilitySO = null;

		// Show abilities panel
		battleManager.ShowAbilitiesButtonsAndDescriptionPanel();

		// Set ability buttons
		battleManager.SetupAbilityButtonsAndDescriptionPanel(selectedWizard);

		// Zoom in the camera
		cameraPanAndZoom.SetUnitSelected(selectedWizard);

		// Display "Choose an ability"
		battleManager.SetBattleText("Choose an ability");

		// Hide every other wizard
		foreach (Wizard otherWizard in battleManager.aliveWizards)
		{
			// Check that the wizard we're going to hide isn't the wizard that was selected
			if (otherWizard == selectedWizard) { continue; }
			else { otherWizard.gameObject.SetActive(false); }
		}
	}

	public void SelectTarget(Unit target)
	{
		// Set selectedTarget
		selectedTarget = target;

		// Zoom out the camera
		cameraPanAndZoom.SetDefault();

		// Clear the battle text
		battleManager.SetBattleText("");

		// Give a math exercise
		StartCoroutine(mathManager.GiveMathExercise());
	}

	public void ActivateAbility(float mathResultMultiplier)
	{
		// Activate the ability
		if (selectedAbilitySO.TargetType == AbilitySO.Targets.NONE) { selectedAbilitySO.Activate(mathResultMultiplier); }       // ability is untargeted
		else { selectedAbilitySO.Activate(selectedTarget, mathResultMultiplier); }												// ability is targeted

		// Remove any enemies that died from aliveEnemies
		List<Unit> deadEnemies = battleManager.aliveEnemies.FindAll(enemy => enemy.CurrentHealth <= 0);		// save the enemies that died so we can hide them later
		battleManager.aliveEnemies.RemoveAll(enemy => enemy.CurrentHealth <= 0);							// remove

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

		// Check if need to change state depending on the state of the enemies
		if (battleManager.aliveEnemies.Count > 0)       // there are enemies alive 
		{
			if (actionsRemaining > 0)                   // there are actions remaining, wait for next player action
			{
				// Display "Select a wizard"
				battleManager.SetBattleText("Select a wizard");
			}
			else                                        // no actions remaining, set to enemy turn
			{
				// Clear battle text
				battleManager.SetBattleText("");

				battleManager.SetEnemyTurn();
			}
		}
		else                                            // all enemies have died, set to won
		{
			// Clear battle text
			battleManager.SetBattleText("");

			battleManager.SetWon();
		}
	}
	
	public void OnEndTurnButtonPressed()
	{
		// Check that it's the player's turn
		if (battleManager.State == BattleManager.BattleState.PLAYER_TURN)
		{
			// Reset all selected things
			selectedWizard = null;
			selectedAbilitySO = null;
			selectedTarget = null;

			// Set actions remaining to 0 and display it
			actionsRemaining = 0;
			battleManager.SetActionsNumText(actionsRemaining.ToString());

			// Clear battle text
			battleManager.SetBattleText("");

			// Hide abilities panel
			battleManager.HideAbilityButtonsAndDescriptionPanel();

			// Set enemy turn
			battleManager.SetEnemyTurn();
		}
	}
}
