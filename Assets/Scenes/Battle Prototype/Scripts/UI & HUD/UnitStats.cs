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

	public void UpdateDisplay(Unit unit)
    {
		// Set variables
		portrait.sprite = unit.Portrait;
		nameText.text = unit.Name;
		healthBar.value = unit.CurrentHealth / unit.MaxHealth;
		healthText.text = Mathf.Ceil(unit.CurrentHealth) + " / " + Mathf.Ceil(unit.MaxHealth);
		physicalAttackText.text = Mathf.Ceil(unit.PhysicalAttack).ToString();
		critChanceText.text = Mathf.Ceil(unit.CritChance).ToString();
		armorText.text = Mathf.Ceil(unit.Armor).ToString();
		spellPowerText.text = Mathf.Ceil(unit.SpellPower).ToString();
		spellBreakText.text = Mathf.Ceil(unit.SpellBreak).ToString();
		spellDefenseText.text = Mathf.Ceil(unit.SpellDefense).ToString();
    }
}
