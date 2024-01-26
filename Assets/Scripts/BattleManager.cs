using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleManager : MonoBehaviour
{
	public BattleState state;

	[SerializeField] TextMeshProUGUI dialogueText;
	[SerializeField] GameObject abilitiesPanel;

    [SerializeField] GameObject wizardPrefab;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform wizardSlot;
    [SerializeField] Transform enemySlot;

	Unit wizardUnit;
	Unit enemyUnit;

    void Start()
	{
		// Set state to start, do starting stuff
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{
        // Set dialogue text
        dialogueText.text = "BATTLE START !!!";

		// Hide abilities panel
		abilitiesPanel.SetActive(false);

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

	IEnumerator PlayerAttack()
	{
		// might want to set state to enemy turn immediately so player can't spam abilities

		bool enemyIsDead = enemyUnit.TakeDamage(wizardUnit.dmg);
		// update enemy hp in hud
		dialogueText.text = "Great mathing!";		// get it wrong = "Nice try"

		yield return new WaitForSeconds(2f);

		if (enemyIsDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = "Enemies are taking their turn";

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
            dialogueText.text = "You were defeated";
        }
	}

	void PlayerTurn()
	{
		// Set dialogue text
        dialogueText.text = "Choose an action";

		// Show abilities panel
		abilitiesPanel.SetActive(true);
	}

	IEnumerator PlayerHeal()
	{
		wizardUnit.Heal(5);
        // update wizard hp in hud
        dialogueText.text = "Great mathing!";       // get it wrong = "Nice try"

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

        // Hide abilities panel
        abilitiesPanel.SetActive(false);

        StartCoroutine(PlayerAttack());
	}
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        // Hide abilities panel
        abilitiesPanel.SetActive(false);

        StartCoroutine(PlayerHeal());
    }

}
