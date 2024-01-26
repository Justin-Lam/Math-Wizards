using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chibi : MonoBehaviour
{
	BattleManager battleManager;

    void Start()
    {
        battleManager = (BattleManager)FindAnyObjectByType(typeof(BattleManager));
    }

    void OnMouseDown()
	{
        if (battleManager.state == BattleState.PLAYERTURN)
            battleManager.ShowAbilitiesPanel();
	}
}
