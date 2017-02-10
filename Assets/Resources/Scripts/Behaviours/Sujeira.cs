using UnityEngine;
using System.Collections;

public class Sujeira : MonoBehaviour {

	public float _distancia = 1.5f;
	public float _velocidadeVoo = 5f;
	bool _puxando = false;
	bool _voando = false;
	Vector2 _direcaoVoo;
	Vector2 _posicaoInicialArraste;
	MinigameSujeira _minigame;



	// Use this for initialization
	void Start () {
		_minigame = transform.parent.GetComponent<MinigameSujeira> ();
	}
	
	// Update is called once per frame
	void Update () {



		if(_puxando && !_voando && _minigame._rodando){
			if (Input.GetMouseButtonUp (0)) {
				_puxando = false;
				if(Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), _posicaoInicialArraste) >= Mathf.Abs(_distancia)){
					_minigame.ContarSujeira ();
					GetComponent<BoxCollider2D> ().enabled = false;
					_voando = true;
					_direcaoVoo = ((Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition) - _posicaoInicialArraste);
				}
			}
		}

		if (_voando) {
			transform.position += (Vector3) (_direcaoVoo * _velocidadeVoo * Time.deltaTime);
		}

	}

	void OnMouseDown(){
		if (!_minigame._rodando) {
			return;
		}
		_puxando = true;
		_posicaoInicialArraste = transform.position;
	}
}
