using UnityEngine;
using System.Collections;

public class MensagemControle : MonoBehaviour {

	// Use this for initialization
	public GUIText gameOverTxt;
	public GUIText restartTxt;
	public GUIText venceuTxt;

	public bool gameOver;
	public bool restart;
	public bool venceu;

	void Start () {
		gameOver = false;
		restart = false;
		venceu = false;
		gameOverTxt.text = "";
		restartTxt.text = "";
		venceuTxt.text = "";
	}
	
	void Update () {
		if (gameOver) {
			restartTxt.text = "Pressione 'R' para Restart";
			restart = true;
		}
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public void GameOver()
	{
		gameOverTxt.text = "Game Over!!!!";
		gameOver = true;
	}

	public void Venceu()
	{
		venceuTxt.text = "Voce Venceu!!!";
		restartTxt.text = "Pressione 'R' para Restart";
		restart = true;
	}
}
