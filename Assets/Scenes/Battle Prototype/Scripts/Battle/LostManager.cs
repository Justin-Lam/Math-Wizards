using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostManager : MonoBehaviour
{
	[SerializeField] BattleManager battleManager;

	public void SetupLost()
	{
		// Set dialogue
		battleManager.SetBattleText("You were defeated...");
	}
}
