using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButtonsAndDescriptionPanel : MonoBehaviour
{
	[Header("Description Panel")]
	[SerializeField] GameObject descriptionPanelGO;
	[SerializeField] TextMeshProUGUI descriptionText;

	[Header("Button 1")]
	[SerializeField] Image ability1Image;
	[SerializeField] Button ability1Button;
	[SerializeField] TextMeshProUGUI ability1NameText;

	[Header("Button 2")]
	[SerializeField] Image ability2Image;
	[SerializeField] Button ability2Button;
	[SerializeField] TextMeshProUGUI ability2NameText;

	[Header("Button 3")]
	[SerializeField] Image ability3Image;
	[SerializeField] Button ability3Button;
	[SerializeField] TextMeshProUGUI ability3NameText;

	[Header("Button 4")]
	[SerializeField] Image ability4Image;
	[SerializeField] Button ability4Button;
	[SerializeField] TextMeshProUGUI ability4NameText;

	AbilitySO[] abilities = new AbilitySO[4];

	public void Setup(Unit wizard)
	{
		// Get abilities
		abilities[0] = wizard.Abilities[0];
		abilities[1] = wizard.Abilities[1];
		abilities[2] = wizard.Abilities[2];
		abilities[3] = wizard.Abilities[3];

		// Clear and hide the description panel
		descriptionText.text = "";
		descriptionPanelGO.SetActive(false);
		
		// Setup button 1
		ability1Image.color = abilities[0].ButtonColor;
		ability1NameText.text = abilities[0].Name;

		// Setup button 2
		ability2Image.color = abilities[1].ButtonColor;
		ability2NameText.text = abilities[1].Name;

		// Setup button 3
		ability3Image.color = abilities[2].ButtonColor;
		ability3NameText.text = abilities[2].Name;

		// Setup button 4
		ability4Image.color = abilities[3].ButtonColor;
		ability4NameText.text = abilities[3].Name;
	}


	public void OnAbility1Hovered() { SetDescriptionText(0); }
	public void OnAbility2Hovered() { SetDescriptionText(1); }
	public void OnAbility3Hovered() { SetDescriptionText(2); }
	public void OnAbility4Hovered() { SetDescriptionText(3); }
	void SetDescriptionText(int abilityNum)
	{
		// Show the description panel
		descriptionPanelGO.SetActive(true);

		// Set the description text
		descriptionText.text = abilities[abilityNum].GetDescription();
	}

	public void OnAbilityUnHovered()
	{
		// Clear the description text
		descriptionText.text = "";

		// Hide the description panel
		descriptionPanelGO.SetActive(false);
	}
}
