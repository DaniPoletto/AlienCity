using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuControle : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 100;
		const int buttonHeight = 30;

		if (GUI.Button (
			new Rect (Screen.width / 2 - (buttonWidth / 2), 
		          (2 * Screen.height / 5f)+50 - (buttonWidth / 2),
		          buttonWidth, buttonHeight),
			"Jogar")) 
		{
			SceneManager.LoadScene("Jogo");
		}
		if (GUI.Button (
			new Rect (Screen.width / 2 - (buttonWidth / 2), 
		          (2 * Screen.height / 5f)+100 - (buttonWidth / 2),
		          buttonWidth, buttonHeight),
			"Configuraçoes")) 
		{
			SceneManager.LoadScene("Config");
		}
		if (GUI.Button (
			new Rect (Screen.width / 2 - (buttonWidth / 2), 
		          (2 * Screen.height / 5f)+150 - (buttonWidth / 2),
		          buttonWidth, buttonHeight),
			"Sair")) 
		{
			Application.Quit();
		}
	}
}
