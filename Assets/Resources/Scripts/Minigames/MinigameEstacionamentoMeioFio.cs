using UnityEngine;
using System.Collections;
using System.Linq;

public class MinigameEstacionamentoMeioFio : Minigame {

	public CarroMeioFio[] _carros;
	[Range(0,6)]
	public int _carrosErrados = 3;

	public GameObject _imagemVitoria;
	public GameObject _imagemDerrota;

	int _contCarros;

	System.Random rng = new System.Random ();
	void Start(){
		_carrosErrados += Configs.FASE;
		var ce = Enumerable.Range (0, _carros.Length).OrderBy (x => rng.Next ()).Take (_carrosErrados).ToList();
		foreach (int c in ce) {
			_carros[c].Afastar ();
		}
		_contCarros = _carrosErrados;
	}

	public void ContaCarro(){
		_contCarros--;
		if (_contCarros <= 0) {
			Ganhar ();
		}
	}

	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		if (_contCarros <= 0) {
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
