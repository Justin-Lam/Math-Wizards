using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostManager : MonoBehaviour
{
	[SerializeField] UIHUDManager uiHudManager;

	public void SetupLost()
	{
		// Set dialogue
		uiHudManager.SetBattleText("You were defeated...");
	}
}
