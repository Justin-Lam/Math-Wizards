using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WizardData
{
	public WizardSO wizard;
	public int slot;
}

[System.Serializable]
public class EnemyData
{
	public EnemySO enemy;
	public int slot;
}

[System.Serializable]
public class Wave
// List of UnitDatas of enemies
{
	public List<EnemyData> enemies = new List<EnemyData>();
}

public class BattleData : MonoBehaviour
{
	[Header("Wizard Data")]
	public List<WizardData> wizards = new List<WizardData>();

	[Header("Enemy Data")]
	public List<Wave> waves	= new List<Wave>();

	int maxUnits = 9;


	void OnValidate()
	{
		// Ensure there aren't more than maxUnits wizards
		if (wizards.Count > maxUnits)
		{
			wizards.RemoveRange(maxUnits, wizards.Count - maxUnits);
		}

		// For each wave, ensure there aren't more than maxUnits enemies
		foreach (Wave wave in waves)
		{
			if (wave.enemies.Count > maxUnits)
			{
				wave.enemies.RemoveRange(maxUnits, wave.enemies.Count - maxUnits);
			}
		}
	}
}
