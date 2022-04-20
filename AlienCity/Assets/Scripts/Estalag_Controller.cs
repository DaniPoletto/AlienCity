using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estalag_Controller : MonoBehaviour {
    // Use this for initialization
    private Animator anim;
    public GameObject Player;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        PlayerController pc = Player.gameObject.GetComponent<PlayerController>();
        int estag_cai = pc.estag_cai;
        if (estag_cai==1)
        {

            anim.SetTrigger("cai_e");
        }
        else if (estag_cai == 2)
        {
            anim.SetTrigger("cai_e2");
        }
    }
}
