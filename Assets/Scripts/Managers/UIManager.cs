using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public string currentScene {get {return SceneManager.GetActiveScene().name;}}
	
	void Start()
	{
		GameManager.instance.uiManager = this;
	}
	
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	
	public void Quit()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
