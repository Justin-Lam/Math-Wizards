using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonManager : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;

	public void SetupWon()
    {
		// Set dialogue
		battleManager.SetBattleText("You won the battle!");
	}
}
