using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
    void OnMouseDown()
    // For selecting a wizard
    {
        // Get the BattleManager script
        GameObject bm = GameObject.Find("Battle Manager");          // "Battle Manager"
        BattleManager bms = bm.GetComponent<BattleManager>();       // "BattleManager Script"

        // Show abilities if it's player's turn
        if (bms.state == BattleState.PLAYERTURN)
            bms.ShowAbilitiesPanel();
    }
}
