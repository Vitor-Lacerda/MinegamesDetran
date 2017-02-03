using UnityEngine;
using System.Collections;

public class CarroMeioFio : MonoBehaviour {

	bool _arrastando = false;
	bool _posicionado = true;

	Vector2 _posicaoInicialArraste;

	public float _distancia = 1f;

	MinigameEstacionamentoMeioFio _minigame;

	void Start(){
		_minigame = GetComponentInParent<MinigameEstacionamentoMeioFio> ();
	}

	// Update is called once per frame
	void Update () {

		if(_arrastando && !_posicionado){
			if((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - _posicaoInicialArraste.x) * Mathf.Sign(_distancia) >= Mathf.Abs(_distancia)){
				transform.localPosition += Vector3.right * _distancia;
				Posicionar ();
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			_arrastando = false;
		}
	}

	public void Afastar(){
		transform.localPosition -= Vector3.right;
		_posicionado = false;
	}

	void Posicionar(){
		_posicionado = true;
		_arrastando = false;
		_minigame.ContaCarro ();
	}

	void OnMouseDown(){
		if (!_posicionado) {
			_arrastando = true;
			_posicaoInicialArraste = transform.position;
		}
	}
}
