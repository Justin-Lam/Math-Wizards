using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleManager : MonoBehaviour
{
	public BattleState state;

	// UI
	[SerializeField] TextMeshProUGUI dialogueText;
	[SerializeField] GameObject leftTimer;
	[SerializeField] GameObject rightTimer;
	[SerializeField] GameObject answers;
	[SerializeField] GameObject abilitiesPanel;

	// Wizards and enemies
	[SerializeField] GameObject wizardPrefab;
	[SerializeField] GameObject enemyPrefab;
	Unit wizardUnit;
	Unit enemyUnit;

	// Slots (should be Grids instead?)
	[SerializeField] Transform wizardSlot;
	[SerializeField] Transform enemySlot;

	string action;

	void Start()
	{
		// Set state to start, set up the battle
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{
		// Hide UI stuff
		leftTimer.SetActive(false);
		rightTimer.SetActive(false);
		answers.SetActive(false);
		abilitiesPanel.SetActive(false);

		// Set dialogue text
		dialogueText.text = "BATTLE START !!!";

		// Spawn wizards
		GameObject wizardGO = Instantiate(wizardPrefab, wizardSlot);
		wizardUnit = wizardGO.GetComponent<Unit>();

		// Spawn enemies
		GameObject enemyGO = Instantiate(enemyPrefab, enemySlot);
		enemyUnit = enemyGO.GetComponent<Unit>();

		// Set to player turn
		yield return new WaitForSeconds(2f);
		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	void PlayerTurn()
	{
		// Set dialogue text
		dialogueText.text = "Select a wizard";
	}

	public void ShowAbilitiesPanel()
	{
		// Show abilities panel
		abilitiesPanel.SetActive(true);

		// Set dialogue text
		dialogueText.text = "Choose an ability";
	}

	public void OnAttackButton()
	{
		action = "attack";

		// Hide abilities panel
		abilitiesPanel.SetActive(false);

		GenerateMathQuestion();
	}
	public void OnHealButton()
	{
		action = "heal";

		// Hide abilities panel
		abilitiesPanel.SetActive(false);

        GenerateMathQuestion();
    }

	void GenerateMathQuestion()
	{
		int x = Random.Range(1, 20);
		int y = Random.Range(1, 20);
		int answer = x + y;

		dialogueText.text = x + " + " + y + " = ???";

		answers.SetActive(true);

		answers.GetComponent<Answers>().SetAnswers(answer);
	}

	public void AnswerButtonPressed(bool result)
	{
        answers.SetActive(false);

        if (result)
		{
			if (action == "attack")
				StartCoroutine(PlayerAttack());
			else if (action == "heal")
				StartCoroutine(PlayerHeal());
		}
		else
		{
			StartCoroutine(UnsuccessfulAbility());
		}
	}

	IEnumerator UnsuccessfulAbility()
	// Player either chose the wrong answer or didn't answer in time
	{
		// Set state to enemy turn immediately so player can't spam abilities
		state = BattleState.ENEMYTURN;

		// Set dialogue text
		dialogueText.text = "Wrong answer";

		yield return new WaitForSeconds(2f);

		StartCoroutine(EnemyTurn());
	}

	IEnumerator PlayerAttack()
	{
		// Set state to enemy turn immediately so player can't spam abilities
		state = BattleState.ENEMYTURN;

		// Damage the enemy and record their state (dead or alive)
		bool enemyIsDead = enemyUnit.TakeDamage(wizardUnit.dmg);
		dialogueText.text = "Great mathing!";

		yield return new WaitForSeconds(2f);

		if (enemyIsDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			StartCoroutine(EnemyTurn());
		}
	}

    IEnumerator PlayerHeal()
    {
        // Set state to enemy turn immediately so player can't spam abilities
        state = BattleState.ENEMYTURN;

        wizardUnit.Heal(5);
        dialogueText.text = "Great mathing!";

        yield return new WaitForSeconds(2f);

        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
	{
		dialogueText.text = "Enemies' Turn";

		yield return new WaitForSeconds(1f);

		bool wizardIsDead = wizardUnit.TakeDamage(enemyUnit.dmg);
		// update wizard hp in hud

		yield return new WaitForSeconds(1f);

		if (wizardIsDead)
		{
			state = BattleState.LOST;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}
	}

	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";

		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated...";
		}
	}
}
