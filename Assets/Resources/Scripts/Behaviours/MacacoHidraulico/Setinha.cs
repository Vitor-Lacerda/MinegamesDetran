using UnityEngine;
using System.Collections;

public class Setinha : MonoBehaviour {

	bool _naRegiaoCerta = false;
	Minigame _minigame;
	Shaking _shaker;

	void Start(){
		_minigame = GetComponentInParent<Minigame> ();
		_shaker = GetComponent<Shaking> ();
		_shaker._frequency += 0.1f * Configs.FASE;
	}

	void Update(){

		_shaker._rodando = _minigame._rodando;

		if (Input.GetMouseButtonDown (0)) {
			if (_naRegiaoCerta) {
				_minigame.Ganhar ();
			} else {
				_minigame.Perder ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		_naRegiaoCerta = true;
	}

	void OnTriggerExit2D(Collider2D col){
		_naRegiaoCerta = false;
	}

}
