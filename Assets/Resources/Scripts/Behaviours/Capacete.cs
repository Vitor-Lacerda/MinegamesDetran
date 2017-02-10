using UnityEngine;
using System.Collections;

public class Capacete : MonoBehaviour {

	public float _distancia = 0.5f;
	public Vector2 _multiplicadores;

	// Use this for initialization
	void Awake () {
		transform.position += new Vector3 (_multiplicadores.x * _distancia * Configs.FASE, _multiplicadores.y * _distancia * Configs.FASE,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
