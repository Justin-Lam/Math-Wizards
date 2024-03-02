using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTextDestroy : MonoBehaviour
{
	[SerializeField] PopupText popupText;

	public void Destroy()
	{
		popupText.Destroy();
	}
}
