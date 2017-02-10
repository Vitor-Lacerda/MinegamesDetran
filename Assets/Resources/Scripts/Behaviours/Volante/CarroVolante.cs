using UnityEngine;
using System.Collections;

public class CarroVolante : MonoBehaviour {

	public float _velocidade;
	public float _velocidadeAngular;
	public float _angulo;
	public float _distanciaRe;
	public bool _sairFora;

	public Volante _volante;
	MinigameVolante _minigame;


	// Use this for initialization
	void Start () {
		//StartCoroutine (SairDaVaga ());
		_minigame = transform.parent.GetComponent<MinigameVolante> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (_sairFora) {
			transform.position += transform.up * _velocidade * Time.deltaTime;
		}
	}

	public IEnumerator SairDaVaga(){
		_volante._funcionando = false;
		float acumulador = 0;
		float acumuladorDistancia = 0;
		float multi = -_velocidadeAngular;
		while (Mathf.Abs(acumulador) <= _angulo) {
			transform.localEulerAngles += Vector3.forward * multi;
			transform.localPosition -= transform.up * _velocidade * Time.deltaTime;
			acumuladorDistancia += _velocidade * Time.deltaTime;
			acumulador += multi;
			yield return null;
		}

		while (acumuladorDistancia <= _distanciaRe) {
			transform.localPosition += transform.up * _velocidade * Time.deltaTime;
			acumuladorDistancia += _velocidade * Time.deltaTime;
			yield return null;
		}
		_volante._funcionando = true;
		_sairFora = true;
		_minigame.Ganhar ();
		yield return null;
	}

}
