using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour
{
	[SerializeField] Image portrait;
	[SerializeField] TextMeshProUGUI nameText;
	[SerializeField] Slider healthBar;
	[SerializeField] TextMeshProUGUI healthText;
	[SerializeField] TextMeshProUGUI physicalAttackText;
	[SerializeField] TextMeshProUGUI critChanceText;
	[SerializeField] TextMeshProUGUI armorText;
	[SerializeField] TextMeshProUGUI spellPowerText;
	[SerializeField] TextMeshProUGUI spellBreakText;
	[SerializeField] TextMeshProUGUI spellDefenseText;

	public void UpdateDisplay(UnitSO unitSO, float currentHealth)
    {
		// Set variables
		portrait.sprite = unitSO.portrait;
		nameText.text = unitSO.name;
		healthBar.value = currentHealth / unitSO.maxHealth;
		healthText.text = currentHealth + " / " + unitSO.maxHealth;
		physicalAttackText.text = unitSO.physicalAttack.ToString();
		critChanceText.text = unitSO.critChance.ToString();
		armorText.text = unitSO.armor.ToString();
		spellPowerText.text = unitSO.spellPower.ToString();
		spellBreakText.text = unitSO.spellBreak.ToString();
		spellDefenseText.text = unitSO.spellDefense.ToString();
    }
}
