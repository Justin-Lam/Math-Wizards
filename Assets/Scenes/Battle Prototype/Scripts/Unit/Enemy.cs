using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    EnemySO enemySO;
	public EnemyAISO EnemyAISO => enemySO.EnemyAISO;

	public void Initialize(EnemySO inputEnemySO)
    {
		// Initialize enemy specific stuff
		enemySO = inputEnemySO;
		enemySO.EnemyAISO.user = this;

		// Initialize general unit stuff
		InitializeUnit(enemySO);
	}
}
