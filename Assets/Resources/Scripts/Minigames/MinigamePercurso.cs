using UnityEngine;
using System.Collections;

public class MinigamePercurso : Minigame {

	public GameObject[] _percursos;
	public CarroPercurso _carro;

	void Start(){
		_percursos [0].SetActive (true);
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
		yield return new WaitForSeconds (0.5f);
		yield return base.RotinaDerrota ();
	}




}
