using UnityEngine;
using System.Collections;

public class InstanciaPedras : MonoBehaviour {

	public GameObject pedras;
	public Vector3 PosCriacao;
	public int ContaPedras;
	public float EsperaCriacao;


	void Start () {
		StartCoroutine (SpawnPedras ());
	}

	IEnumerator SpawnPedras ()
	{
		for (int i = 0; i < ContaPedras; i++)
		{
			GameObject ped = pedras;
			Vector3 spawnPosition = new Vector3 (Random.Range (-PosCriacao.x, PosCriacao.x),PosCriacao.y, Random.Range (-PosCriacao.z, PosCriacao.z));
			Instantiate (ped, spawnPosition, Quaternion.Euler(270, 0, 0));
			yield return new WaitForSeconds (EsperaCriacao);
		}
		
	}



}
