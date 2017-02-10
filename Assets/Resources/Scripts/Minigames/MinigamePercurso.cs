using UnityEngine;
using System.Collections;

public class MinigamePercurso : Minigame {

	public GameObject[] _percursos;
	public CarroPercurso _carro;

	void Start(){
		int i = Configs.FASE;
		if (i >= _percursos.Length) {
			i = _percursos.Length - 1;
		}


		_percursos [i].SetActive (true);
	}

	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		if (_rodando) {
			StartCoroutine (_carro.RotinaPercorrePercurso (false));
			_rodando = false;
		}
	}


	protected override IEnumerator RotinaDerrota ()
	{
		yield return new WaitForSeconds (Configs.TEMPOESPERAPADRAO);
		yield return base.RotinaDerrota ();
	}




}
