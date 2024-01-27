using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerResult : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;
    public bool result;

    public void OnAnswerButton()
    {
        battleManager.AnswerButtonPressed(result);
    }
}
