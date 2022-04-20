using UnityEngine;
using System.Collections;

public class RotacionaPedra : MonoBehaviour {
    public GameObject Player;
    void Update () {
		transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);
	}
    void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Player")||(other.gameObject.CompareTag("tiro")))
		{
            PlayerController pc = Player.gameObject.GetComponent<PlayerController>();
            pc.AddScore(100);
            Destroy(gameObject);
        }
	}
}
