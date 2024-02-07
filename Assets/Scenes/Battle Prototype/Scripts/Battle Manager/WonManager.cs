using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonManager : MonoBehaviour
{
	[SerializeField] UIHUDManager uiHudManager;

	public void SetupWon()
    {
		// Set dialogue
		uiHudManager.SetBattleText("You won the battle!");
	}
}
