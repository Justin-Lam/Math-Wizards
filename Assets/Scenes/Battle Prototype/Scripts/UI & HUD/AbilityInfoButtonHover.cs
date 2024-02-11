using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInfoButtonHover : MonoBehaviour
{
	[SerializeField] GameObject nameTextGO;
	[SerializeField] GameObject desciptionPanelGO;

	public void Hovered()
	{
		// Hide button text
		nameTextGO.SetActive(false);

		// Show info panel
		desciptionPanelGO.SetActive(true);
	}
	public void Unhovered()
	{
		// Show button text
		nameTextGO.SetActive(true);

		// Hide info panel
		desciptionPanelGO.SetActive(false);
	}
}
