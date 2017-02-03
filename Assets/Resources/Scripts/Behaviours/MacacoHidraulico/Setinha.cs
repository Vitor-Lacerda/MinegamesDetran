using UnityEngine;
using System.Collections;

public class Setinha : MonoBehaviour {

	bool _naRegiaoCerta = false;
	Minigame _minigame;


	void Start(){
		_minigame = GetComponentInParent<Minigame> ();
	}

	void Update(){
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
