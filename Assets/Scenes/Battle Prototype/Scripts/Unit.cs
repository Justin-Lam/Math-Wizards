using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] string Unitname;
    [SerializeField] int maxHP;
    [SerializeField] int currentHP;
	//[SerializeField] protected int Unitlevel;
	[SerializeField] int dmg;

	[SerializeField] FloatingHealthBar healthBarScript;

    void Start()
    {
        // Set the health bar
        healthBarScript.UpdateHealthBar(currentHP, maxHP);
    }

	public bool IsAlive() { return currentHP > 0; }

    public void TakeDamage(int amount)
	{
		// Take damage
		currentHP -= amount;

        // Update health bar
        healthBarScript.UpdateHealthBar(currentHP, maxHP);
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

	public string GetUnitName() { return Unitname; }
	public int GetMaxHP() {  return maxHP; }
	public int GetCurrentHP() {  return currentHP; }
	public int GetDmg() { return dmg; }
}
