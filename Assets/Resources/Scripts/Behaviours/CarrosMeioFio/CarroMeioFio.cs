using UnityEngine;
using System.Collections;

public class CarroMeioFio : MonoBehaviour {

	bool _arrastando = false;
	bool _posicionado = true;
	public bool _direcaoAleatoria = false;

	Vector2 _posicaoInicialArraste;

	public float _distancia = 1f;

	MinigameEstacionamentoMeioFio _minigame;

	void Awake(){
		if (_direcaoAleatoria) {
			if (Random.Range (0, 10) > 5) {
				_distancia = -_distancia;
			}
		}
		_distancia += Mathf.Sign (_distancia) * 0.1f * Configs.FASE;
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
		transform.localPosition -= Vector3.right * _distancia;
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
