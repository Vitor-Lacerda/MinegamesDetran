using UnityEngine;
using System.Collections;

public class CarroAbrirCaminho : MonoBehaviour {

	BoxCollider2D _colisor;
	[Range(-1,1)]
	public int _direcao;
	public float _velocidadeAngular;
	public float _velocidade;
	public float _distancia = 10f;
	public float _angulo = 30f;

	MinigameAbrirCaminho _minigame;

	void Awake(){
		_colisor = GetComponent<BoxCollider2D> ();
		_minigame = GetComponentInParent<MinigameAbrirCaminho> ();
	}


	void OnMouseDown(){
		_colisor.enabled = false;
		_minigame.ContarCarro ();
		StartCoroutine (SairDoCaminho ());
	}

	IEnumerator SairDoCaminho(){
		float acumulador = 0;
		float acumuladorDistancia = 0;
		float multi = (-_direcao) * _velocidadeAngular;
		while (Mathf.Abs(acumulador) <= _angulo) {
			transform.localEulerAngles += Vector3.forward * multi;
			transform.localPosition += transform.up * _velocidade * Time.deltaTime;
			acumuladorDistancia += _velocidade * Time.deltaTime;
			acumulador += multi;
			yield return null;
		}

		while (acumuladorDistancia <= _distancia) {
			transform.localPosition += transform.up * _velocidade * Time.deltaTime;
			acumuladorDistancia += _velocidade * Time.deltaTime;
			yield return null;
		}

		yield return null;
	}

}
