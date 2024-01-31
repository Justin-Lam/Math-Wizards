using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBattle : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;

	public void BecameLost()
	{
		// Set dialogue
		battleManager.dialogueText.text = "You were defeated...";
	}
}
