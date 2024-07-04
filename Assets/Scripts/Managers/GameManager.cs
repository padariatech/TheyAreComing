using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public UIManager uiManager;
	
	public int score;
	
	void Awake()
	{
		if(instance == null && instance != this)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	public void AddScore(int amount)
	{
		score += amount;
		uiManager.GetComponent<LevelUI>().SetScore(score);
	}
}
