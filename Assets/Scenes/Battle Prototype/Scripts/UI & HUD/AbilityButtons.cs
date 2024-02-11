using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButtons : MonoBehaviour
{
	[Header("Button 1")]
	[SerializeField] Image ability1Image;
	[SerializeField] Button ability1Button;
	[SerializeField] TextMeshProUGUI ability1NameText;
	[SerializeField] GameObject ability1DescriptionPanelGO;
	[SerializeField] TextMeshProUGUI ability1DescriptionText;

	[Header("Button 2")]
	[SerializeField] Image ability2Image;
	[SerializeField] Button ability2Button;
	[SerializeField] TextMeshProUGUI ability2NameText;
	[SerializeField] GameObject ability2DescriptionPanelGO;
	[SerializeField] TextMeshProUGUI ability2DescriptionText;

	[Header("Button 3")]
	[SerializeField] Image ability3Image;
	[SerializeField] Button ability3Button;
	[SerializeField] TextMeshProUGUI ability3NameText;
	[SerializeField] GameObject ability3DescriptionPanelGO;
	[SerializeField] TextMeshProUGUI ability3DescriptionText;

	[Header("Button 4")]
	[SerializeField] Image ability4Image;
	[SerializeField] Button ability4Button;
	[SerializeField] TextMeshProUGUI ability4NameText;
	[SerializeField] GameObject ability4DescriptionPanelGO;
	[SerializeField] TextMeshProUGUI ability4DescriptionText;

	public void SetButtons(Unit wizard)
	{
		// Get abilities
		AbilitySO ability1 = wizard.Abilities[0];
		AbilitySO ability2 = wizard.Abilities[1];
		AbilitySO ability3 = wizard.Abilities[2];
		AbilitySO ability4 = wizard.Abilities[3];
		
		// Setup button 1
		ability1Image.color = ability1.ButtonColor;
		ability1NameText.text = ability1.Name;
		ability1DescriptionPanelGO.SetActive(false);
		ability1DescriptionText.text = ability1.GetDescription(wizard);

		// Setup button 2
		ability2Image.color = ability2.ButtonColor;
		ability2NameText.text = ability2.Name;
		ability2DescriptionPanelGO.SetActive(false);
		ability2DescriptionText.text = ability2.GetDescription(wizard);

		// Setup button 3
		ability3Image.color = ability3.ButtonColor;
		ability3NameText.text = ability3.Name;
		ability3DescriptionPanelGO.SetActive(false);
		ability3DescriptionText.text = ability3.GetDescription(wizard);

		// Setup button 4
		ability4Image.color = ability4.ButtonColor;
		ability4NameText.text = ability4.Name;
		ability4DescriptionPanelGO.SetActive(false);
		ability4DescriptionText.text = ability4.GetDescription(wizard);
	}
}
