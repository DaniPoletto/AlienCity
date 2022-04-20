using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreProta : MonoBehaviour {
    // Use this for initialization
    private Animator anim;
    public GameObject Player;
    int n_chaves, pode_abrir;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        PlayerController pc = Player.gameObject.GetComponent<PlayerController>();
        n_chaves = pc.Key();
        pode_abrir = pc.PodeAbrir();
        if (n_chaves==2 && pode_abrir==1)
        {
            Debug.Log("AbreProta");
            anim.SetTrigger("abre");
        }
    }
}
