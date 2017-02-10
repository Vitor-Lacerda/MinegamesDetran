using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinigameTriangulo : Minigame {

	public GameObject _imagemVitoria;
	public GameObject _imagemDerrota;

	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		Perder ();
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
