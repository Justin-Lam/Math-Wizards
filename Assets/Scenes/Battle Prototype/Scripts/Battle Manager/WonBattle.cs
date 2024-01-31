using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonBattle : MonoBehaviour
{
	[SerializeField] BattleManager2 battleManager;

	public void BecameWon()
    {
		// Set dialogue
		battleManager.dialogueText.text = "You won the battle!";
	}
}
