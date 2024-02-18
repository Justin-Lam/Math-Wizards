using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Unit/Enemy")]
public class EnemySO : UnitSO
{
	[SerializeField] EnemyAISO enemyAISO;		public EnemyAISO EnemyAISO => enemyAISO;
}
