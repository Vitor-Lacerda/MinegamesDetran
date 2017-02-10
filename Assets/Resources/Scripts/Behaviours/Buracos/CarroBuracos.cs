using UnityEngine;
using System.Collections;

public class CarroBuracos : MonoBehaviour {

	public Transform[] _posicoesFaixas;
	public int _faixaAtual;
	Minigame _minigame;

	// Use this for initialization
	void Start () {
		_faixaAtual = 1;
		_minigame = transform.parent.GetComponent<Minigame> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MudarFaixa(int i){
		if (i < _posicoesFaixas.Length) {
			transform.position = _posicoesFaixas [i].position;
			_faixaAtual = i;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		_minigame.Perder ();
	}
}
