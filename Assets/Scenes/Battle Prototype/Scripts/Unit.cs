using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] string Unitname;
    [SerializeField] int maxHP;
    [SerializeField] int currentHP;
    //[SerializeField] int Unitlevel;
    public int dmg;

	[SerializeField] FloatingHealthBar healthBarScript;

    void Start()
    {
        // Set the health bar
        healthBarScript.UpdateHealthBar(currentHP, maxHP);
    }

    public bool TakeDamage(int amount)
	// Returns true if the unit died, false otherwise
	{
		// Take damage
		currentHP -= amount;

        // Update health bar
        healthBarScript.UpdateHealthBar(currentHP, maxHP);

		// Return the state of the unit (dead or alive)
		return currentHP <= 0;
	}

	public void Heal(int amount)
	{
		// Heal
		currentHP += amount;

        // Update health bar
        healthBarScript.UpdateHealthBar(currentHP, maxHP);

        // Fix health if needed
        if (currentHP > maxHP)
			currentHP = maxHP;
	}
}
