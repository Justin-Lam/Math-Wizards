using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
	WizardSO wizardSO;

	public void Initialize(WizardSO inputwizardSO)
	{
		// Initialize enemy specific stuff
		wizardSO = inputwizardSO;

		// Initialize general unit stuff
		InitializeUnit(wizardSO);
	}
}
