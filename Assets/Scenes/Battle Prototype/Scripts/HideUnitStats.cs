using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnitStats : MonoBehaviour
{
	[SerializeField] UIHUDManager uiHudManager;

	void OnMouseEnter()
	// For when anything is unhovered
	{
		// Hide wizard and enemy stats HUD
		uiHudManager.HideWizardStats();
		uiHudManager.HideEnemyStats();
	}
}
