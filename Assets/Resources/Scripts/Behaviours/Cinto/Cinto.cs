using UnityEngine;
using System.Collections;

public class Cinto : MonoBehaviour {

	public Transform _encaixe;
	public float _distancia;
	public float _velocidadeRetorno;
	public LineRenderer _lineRenderer;
	public Transform _terceiroPonto;
	public MinigameCinto _minigame;


	Vector3 _posInicial;
	Vector3 _posInicialWorld;
	bool _arrastando = false;
	bool _fechado = false;

	// Use this for initialization
	void Start () {
		_posInicial = transform.localPosition;
		_posInicialWorld = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (_lineRenderer != null) {
			_lineRenderer.SetPositions (new Vector3[]{ _posInicialWorld, transform.position, _terceiroPonto.position });
		}

		if (_fechado)
			return;


		if (_arrastando) {
			Vector3 temp = transform.position;
			temp = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = temp;
		} else {
			transform.localPosition = Vector3.Lerp (transform.localPosition, _posInicial, Time.deltaTime * _velocidadeRetorno);
		}

		if (Input.GetMouseButtonUp (0)) {
			_arrastando = false;
		}
	}

	void OnMouseDown(){
		_arrastando = true;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform == _encaixe && _arrastando) {
			transform.position = _encaixe.position;
			_fechado = true;
			_minigame.ContarCinto ();
		}
	}
}
