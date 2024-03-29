using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupText : MonoBehaviour
{
	public enum Types { PHYSICAL_DAMAGE, MAGIC_DAMAGE, TRUE_DAMAGE, HEAL}

	[Header("Key Variables")]
	[SerializeField] TextMeshProUGUI text;
	[SerializeField] float spawnPositionYOffset;
	[SerializeField] Vector2 randomSpawnPositionOffsetRanges;

	[Header("Colors")]
	[SerializeField] Color physicalDamageColor;
	[SerializeField] Color magicDamageColor;
	[SerializeField] Color trueDamageColor;
	[SerializeField] Color healColor;

	public void Setup(Types type, float num)
	{
		// Set color
		switch(type)
		{
			case Types. PHYSICAL_DAMAGE:
				text.color = physicalDamageColor;
				break;

			case Types. MAGIC_DAMAGE:
				text.color = magicDamageColor;
				break;

			case Types. TRUE_DAMAGE:
				text.color = trueDamageColor;
				break;

			case Types. HEAL:
				text.color = healColor;
				break;

			default:
				Debug.Log("ERROR: Default switch case used in Setup() of PopupText");
				break;
		}

		// Set text
		text.text = Mathf.Ceil(num).ToString();
	}

	void Start()
	{
		// Shift spawn position
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnPositionYOffset, gameObject.transform.position.z);

		// Randomize new spawn position
		gameObject.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(-randomSpawnPositionOffsetRanges.x, randomSpawnPositionOffsetRanges.x),
													gameObject.transform.position.y + Random.Range(-randomSpawnPositionOffsetRanges.y, randomSpawnPositionOffsetRanges.y),
													gameObject.transform.position.z);
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}
}
