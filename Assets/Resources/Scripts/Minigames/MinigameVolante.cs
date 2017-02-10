using UnityEngine;
using System.Collections;

public class MinigameVolante : Minigame {

	public GameObject _imagemDerrota;
	public GameObject _imagemVitoria;

	public CarroVolante _carroVolante;

	public void TirarCarro(){
		StartCoroutine (_carroVolante.SairDaVaga ());
	}



	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		Perder ();
	}

	protected override IEnumerator RotinaVitoria ()
	{

		_rodando = false;
		_imagemVitoria.SetActive (true);
		yield return new WaitForSeconds (Configs.TEMPOESPERAPADRAO);

		yield return base.RotinaVitoria ();
	}

	protected override IEnumerator RotinaDerrota ()
	{
		_rodando = false;
		_imagemDerrota.SetActive (true);

		yield return new WaitForSeconds (Configs.TEMPOESPERAPADRAO);


		yield return base.RotinaDerrota ();
	}
}
