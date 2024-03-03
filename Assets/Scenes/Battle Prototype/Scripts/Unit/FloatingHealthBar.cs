using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
	[Header("Health Bars")]
	[SerializeField] Slider healthBar;
	[SerializeField] Slider greyHealthBar;
	[SerializeField] float moveDelay;
	[SerializeField] float moveSpeed;

	[Header("Animation")]
	[SerializeField] Animator animator;

	public void Initialize()
	{
		healthBar.value = 1f;
		greyHealthBar.value = 1f;
	}

	public IEnumerator TakeDamage(float currentHealth, float maxHealth)
	{
		// Update animator's unitIsAlive
		animator.SetBool("unitIsAlive", currentHealth > 0f);
		if (currentHealth > 0f) { Debug.Log("unit is alive"); }
		else if (currentHealth <= 0f) { Debug.Log("unit is dead"); }

		// Instantly set the health bar to reflect current health
		healthBar.value = currentHealth / maxHealth;

		// Wait for some time
		yield return new WaitForSeconds(moveDelay);

		// Make the grey health bar catch up to the health bar
		while (greyHealthBar.value > healthBar.value)
		{
			greyHealthBar.value -= moveSpeed * Time.deltaTime;
			yield return null;
		}

		// Fix the grey health bar's value if it overshot
		greyHealthBar.value = healthBar.value;
	}

	public IEnumerator Heal(float currentHealth, float maxHealth)
	{
		// Instantly set the grey health bar to reflect current health
		greyHealthBar.value = currentHealth / maxHealth;

		// Wait for some time
		yield return new WaitForSeconds(moveDelay);

		// Make the health bar catch up to the grey health bar
		while (healthBar.value < greyHealthBar.value)
		{
			healthBar.value += moveSpeed * Time.deltaTime;
			yield return null;
		}

		// Fix the health bar's value if it overshot
		healthBar.value = greyHealthBar.value;
	}
}
