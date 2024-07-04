using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	public Action Died;
	[SerializeField] int maxHealthAmount;
	int currentHealth;
	bool isInvincible = false;	

	void Awake()
	{
		currentHealth = maxHealthAmount;
	}

	void Start()
	{
		if(gameObject.tag == "Player") GameManager.instance.uiManager.GetComponent<LevelUI>().SetHealth(currentHealth);
	}
	
	public void DecreaseHealth(int amount = 1)
	{
		//DAMAGE FLASH HERE		
		
		if(isInvincible) return;
		
		currentHealth -= amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealthAmount);
		if(gameObject.tag == "Player") GameManager.instance.uiManager.GetComponent<LevelUI>().SetHealth(currentHealth);
		if(currentHealth <= 0) Died?.Invoke();
	}
	
	public void IncreaseHealth(int amount = 1)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealthAmount);
		if(gameObject.tag == "Player") GameManager.instance.uiManager.GetComponent<LevelUI>().SetHealth(currentHealth);
	}
	
	public void SetMaxHealth(int newAmount)
	{
		maxHealthAmount = newAmount;
		if(gameObject.tag == "Player") GameManager.instance.uiManager.GetComponent<LevelUI>().SetHealth(currentHealth);
	}
	
	public void SetInvincibility(bool state)
	{
		isInvincible = state;
	}
}
