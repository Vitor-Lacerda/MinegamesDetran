using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarroPercurso : MonoBehaviour {

	public float _velocidade = 5;
	Minigame _minigame;
	bool continuar;
	Queue<Transform> _pontosPercurso;

	// Use this for initialization
	void Start () {
		_pontosPercurso = new Queue<Transform> ();
		_minigame = transform.parent.GetComponent<Minigame> ();
		continuar = false;

	}

	void Update(){
		if (continuar) {
			transform.position += transform.up * _velocidade * Time.deltaTime;
		}
	}

	public void AdicionarPonto(Transform ponto){
		_pontosPercurso.Enqueue (ponto);
	}

	public IEnumerator RotinaPercorrePercurso(bool ganhou){
		while (_pontosPercurso.Count > 0) {
			Vector3 posPonto = _pontosPercurso.Dequeue().position;
			Vector3 direcao = posPonto - transform.position;
			direcao.Normalize ();
			while (Vector3.Distance(transform.position, posPonto) > 0.1f) {
				transform.position += direcao * _velocidade * Time.deltaTime;
				transform.up = Vector3.Lerp(transform.up, direcao, Time.deltaTime * 10);
				yield return null;
			}
			yield return null;
		}
		if (ganhou) {
			_minigame.Ganhar ();
		} else {
			_minigame.Perder ();
		}
		continuar = !ganhou;
		yield return null;
	}

}
