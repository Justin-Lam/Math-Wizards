using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHUDManager : MonoBehaviour
{
    [Header("Battle")]
    [SerializeField] GameObject wizardStatsGO;
    [SerializeField] GameObject enemyStatsGO;
    [SerializeField] GameObject abilitiesPanelGO;

    [SerializeField] TextMeshProUGUI battleText;
    [SerializeField] UnitStats wizardStats;
    [SerializeField] UnitStats enemyStats;

    public void ShowWizardStats() { wizardStatsGO.SetActive(true); }
    public void HideWizardStats() { wizardStatsGO.SetActive(false); }
    public void ShowEnemyStats() { enemyStatsGO.SetActive(true); }
    public void HideEnemyStats() { enemyStatsGO.SetActive(false); }
    public void ShowAbilitiesPanel() { abilitiesPanelGO.SetActive(true); }
    public void HideAbilitiesPanel() { abilitiesPanelGO.SetActive(false); }

    public void SetBattleText(string text) {  battleText.text = text; }
    public void SetWizardStats(UnitSO unitSO, float currentHealth) { wizardStats.UpdateDisplay(unitSO, currentHealth); }
    public void SetEnemyStats(UnitSO unitSO, float currentHealth) { enemyStats.UpdateDisplay(unitSO, currentHealth); }



    [Header("Math")]
    [SerializeField] GameObject mathCanvasGO;
    [SerializeField] GameObject timerQuestionAnswersGO;

    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] Answers answers;

    public void ShowMathCanvas() { mathCanvasGO.SetActive(true); }
    public void HideMathCanvas() { mathCanvasGO.SetActive(false); }
    public void ShowTimerQuestionAnswers() { timerQuestionAnswersGO.SetActive(true); }
    public void HideTimerQuestionAnswers() { timerQuestionAnswersGO.SetActive(false); }

    public void ActivateTimer() { StartCoroutine(timer.ActivateTimer()); }
    public void DeactivateTimer() { timer.DeactivateTimer(); }
    public void SetQuestionText(string text) { questionText.text = text; }
    public void SetAnswers(int answer) { answers.SetAnswers(answer); }
}
