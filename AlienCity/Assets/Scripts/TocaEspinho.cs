using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TocaEspinho : MonoBehaviour {

    public int attackDamage = 10;               // The amount of health taken away per attack.
    GameObject player;                          // Reference to the player GameObject.
    PlayerController playerHealth;                  // Reference to the player's health.
                                                    //private float volume;
    private AudioSource audio1;

    // Use this for initialization
    void Start () {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        audio1 = player.GetComponent<AudioSource>();
        playerHealth = player.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
            audio1.Play();
            playerHealth.TakeDamage(attackDamage);
            //Debug.Log("Tocando Espinho");
        }
    }
}
