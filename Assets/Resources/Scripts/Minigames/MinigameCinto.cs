using UnityEngine;
using System.Collections;

public class MinigameCinto : Minigame {

	public GameObject _imagemVitoria;
	public GameObject _imagemDerrota;

	int _cont = 2;

	public void ContarCinto(){
		_cont--;
		if (_cont == 0) {
			Ganhar ();
		}
	}

	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		if (_cont == 0) {
			Ganhar ();
		} else {
			Perder ();
		}
	}

	protected override IEnumerator RotinaVitoria ()
	{

		_imagemVitoria.SetActive (true);

		yield return new WaitForSeconds (Configs.TEMPOESPERAPADRAO);

		yield return base.RotinaVitoria ();
	}


	protected override IEnumerator RotinaDerrota ()
	{

		_imagemDerrota.SetActive (true);

		yield return new WaitForSeconds (Configs.TEMPOESPERAPADRAO);

		yield return base.RotinaDerrota ();
	}
}
