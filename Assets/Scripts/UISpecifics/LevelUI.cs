using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	[SerializeField] Text scoreText;
	[SerializeField] Text healthText;
	
	
	public void SetScore(int score)
	{
		scoreText.text = "SCORE: " + score;
	}
	
	public void SetHealth(int health)
	{
		healthText.text = "HEALTH: " + health;
	}
}
