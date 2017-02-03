using UnityEngine;
using System.Collections;

public class Percurso : MonoBehaviour {

	public CarroPercurso _carro;
	Minigame _minigame;

	int _numeroDeNos;
	int _noAtual;

	// Use this for initialization
	void Start () {
		_minigame = transform.parent.GetComponent<Minigame> ();
		_numeroDeNos = transform.childCount;
		_noAtual = 0;
	}


	public bool ContaNo(int indice){
		if (indice == _noAtual && _minigame._rodando) {
			_noAtual++;
			_carro.AdicionarPonto (transform.GetChild (indice));
			if (_noAtual == _numeroDeNos) {
				Debug.Log ("Ganhou");
				StartCoroutine (_carro.RotinaPercorrePercurso (true));
				_minigame._rodando = false;
			}
			return true;
		} else {
			return false;
		}

	}

}
