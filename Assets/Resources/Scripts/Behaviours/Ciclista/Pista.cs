using UnityEngine;
using System.Collections;

public class Pista : MonoBehaviour {

	public float _velocidade;

	protected CriadorPista _criador;
	protected Vector3 _posicaoViewport;

	void Start(){
		_criador = transform.GetComponentInParent<CriadorPista> ();
	}

	// Update is called once per frame
	void Update () {
		if (_criador._rodando) {
			transform.localPosition -= new Vector3 (0, _velocidade * Time.deltaTime, 0);
			_posicaoViewport = Camera.main.WorldToViewportPoint (transform.localPosition);
			if (_posicaoViewport.y < -1) {
				gameObject.SetActive (false);
				_criador.CriarNovaPista ();
			}
		}
	}
}
