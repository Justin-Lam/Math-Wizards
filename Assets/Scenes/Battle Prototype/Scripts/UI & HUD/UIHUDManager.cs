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
    [SerializeField] AbilityButtons abilityButtons;

    public void ShowWizardStats() { wizardStatsGO.SetActive(true); }
    public void HideWizardStats() { wizardStatsGO.SetActive(false); }
    public void ShowEnemyStats() { enemyStatsGO.SetActive(true); }
    public void HideEnemyStats() { enemyStatsGO.SetActive(false); }
    public void ShowAbilitiesPanel() { abilitiesPanelGO.SetActive(true); }
    public void HideAbilitiesPanel() { abilitiesPanelGO.SetActive(false); }

    public void SetBattleText(string text) {  battleText.text = text; }
    public void SetWizardStats(Unit unit) { wizardStats.UpdateDisplay(unit); }
    public void SetEnemyStats(Unit unit) { enemyStats.UpdateDisplay(unit); }
    public void SetAbilityButtons(Unit wizard) { abilityButtons.SetButtons(wizard); }
}
