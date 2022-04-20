using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class TocaSom : MonoBehaviour {


	//private float volume;
	private AudioSource audio1;

	void Start() {
		audio1 = GetComponent<AudioSource>();
		audio1.Play();
		//audio.Play(44100);
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("PPSom")==1)
		   {
			audio1.mute = false;
		}
		else
		{
			audio1.mute = true;
		}
		audio1.volume = PlayerPrefs.GetFloat("PPVolume");
		//Debug.Log ("Volume:" + audio.volume);
	
	}
}
