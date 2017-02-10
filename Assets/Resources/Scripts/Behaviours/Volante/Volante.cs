using UnityEngine;
using System.Collections;

public class Volante : MonoBehaviour {

	public Transform _sprite;
	public float direcao = 1;
	public bool _funcionando = true;
	public Transform _setaGiro;

	int voltas = 0;
	Vector2 _vetorInicial;
	Vector2 normalInicial;
	float _ultimoAngulo = 0;
	bool _rodando;
	bool volta = false;

	MinigameVolante _minigame;


	// Use this for initialization
	void Start () {
		direcao = -1;
		direcao = Mathf.Sign (direcao);
		_minigame = transform.parent.GetComponent<MinigameVolante> ();
		_rodando = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!_funcionando) {
			return;
		}

		if (_rodando) {
			float angulo = Vector2.Angle (Camera.main.ScreenToWorldPoint (Input.mousePosition).normalized, _vetorInicial);
			float dot = Vector2.Dot (Camera.main.ScreenToWorldPoint (Input.mousePosition).normalized, normalInicial);


			if (dot * direcao < 0) {
				angulo = 360 - angulo;
			}


			if (angulo >= _ultimoAngulo) {
				_ultimoAngulo = angulo;
				if (360 - _ultimoAngulo < 10f) {
					_ultimoAngulo = 0;
					if (!volta) {
						Debug.Log ("Volta");
						volta = true;
						voltas++;
						if (voltas >= 3 + Configs.FASE) {
							voltas = 0;
								_minigame.TirarCarro ();
							} 

						}
						
					}
				}
				if (_ultimoAngulo > 170 && _ultimoAngulo < 190) {
					volta = false;
				}
		}
	

		if (Input.GetMouseButtonUp (0)) {
			_rodando = false;
		}

		_sprite.localEulerAngles = new Vector3 (0, 0, _ultimoAngulo * direcao);

		Debug.DrawLine(Vector3.zero, Vector3.Cross(Vector3.forward,_vetorInicial));
		Debug.DrawLine (Vector3.zero, _vetorInicial);
		Debug.DrawLine (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition));

	}

	void OnMouseDown(){
		if (!_rodando) {
			_vetorInicial = (Vector2)(Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.localPosition);
			normalInicial = Vector3.Cross (Vector3.forward, _vetorInicial);
			_ultimoAngulo = 0;
			_rodando = true;

		}
	}
}
