using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
	/*
	public BattleState state;

	// UI
	[SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject timer;
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
		// Set up battle
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{
		// Set state
        state = BattleState.START;

        // Hide UI stuff
        timer.SetActive(false);
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

		// Set to player turn after 2 seconds
		yield return new WaitForSeconds(2f);
		PlayerTurn();
	}

	void PlayerTurn()
	{
        // Set state
        state = BattleState.PLAYERTURN;

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

		// Generate math question and show timer
        GenerateMathQuestion();
    }

	void GenerateMathQuestion()
	{
		// Timer stuff
        timer.SetActive(true);
		StartCoroutine(timer.GetComponent<Timer>().ActivateTimer());

		// Qustion stuff
        int x = Random.Range(1, 20);
		int y = Random.Range(1, 20);
		int answer = x + y;

		dialogueText.text = x + " + " + y + " = ???";

		answers.SetActive(true);

		answers.GetComponent<Answers>().SetAnswers(answer);
	}

	public void AnswerButtonPressed(bool result)
	{
		// Hide stuff
		timer.GetComponent<Timer>().DeactivateTimer();
		timer.SetActive(false);
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
			StartCoroutine(WrongAnswer());
		}
	}

	IEnumerator WrongAnswer()
	{
		// Set state to enemy turn immediately so player can't spam abilities
		state = BattleState.ENEMYTURN;

		// Set dialogue text
		dialogueText.text = "Wrong answer";

		yield return new WaitForSeconds(2f);

		StartCoroutine(EnemyTurn());
	}

	public void OutOfTime()
	{
        // Set state to enemy turn immediately so player can't spam abilities
        state = BattleState.ENEMYTURN;

        // Hide Stuff
        timer.SetActive(false);
        answers.SetActive(false);

        // Set dialogue text
        dialogueText.text = "Out of time";

		StartCoroutine(WaitThenSetEnemyTurn());
    }

	IEnumerator WaitThenSetEnemyTurn()
	{
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
			WinBattle();
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
        // Set state
        state = BattleState.ENEMYTURN;

        dialogueText.text = "Enemies' Turn";

		yield return new WaitForSeconds(1f);

		bool wizardIsDead = wizardUnit.TakeDamage(enemyUnit.dmg);
		// update wizard hp in hud

		yield return new WaitForSeconds(1f);

		if (wizardIsDead)
		{
			LoseBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}
	}

	void WinBattle()
	{
        // Set state
        state = BattleState.WON;

		// Set dialogue text
        dialogueText.text = "You won the battle!";
    }

	void LoseBattle()
	{
        // Set state
        state = BattleState.LOST;

		// Set dialogue text
        dialogueText.text = "You were defeated...";
    }
	*/
}
