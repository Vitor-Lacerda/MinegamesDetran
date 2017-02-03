using UnityEngine;
using System.Collections;

public class AmbulanciaAbrirCaminho : MonoBehaviour {
	public float _velocidade = 8;
	public float _distanciaRaio = 3;
	public bool _movendo = false;


	// Update is called once per frame
	void Update () {
		if (!_movendo)
			return;

		transform.localPosition += transform.up * _velocidade * Time.deltaTime;
		/*
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, _distanciaRaio);
		if (hit.collider == null) {
		}
		*/
	}

	void OnTriggerEnter2D(Collider2D other){
		_velocidade = 0;
	}
}
