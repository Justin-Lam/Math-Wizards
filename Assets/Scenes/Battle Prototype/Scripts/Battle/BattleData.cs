using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData
{
	public UnitSO unit;
	public int slot;
}

[System.Serializable]
public class Wave
// List of UnitDatas of enemies
{
	public List<UnitData> enemies = new List<UnitData>();
}

public class BattleData : MonoBehaviour
{
	[Header("Wizard Data")]
	public List<UnitData> wizards = new List<UnitData>();

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
