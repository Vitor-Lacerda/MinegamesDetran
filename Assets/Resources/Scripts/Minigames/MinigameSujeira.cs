using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MinigameSujeira : Minigame {

	public int _cont;
	public List<GameObject> _sujeiras;

	public GameObject _imagemVitoria;
	public GameObject _imagemDerrota;

	void Start(){
		_cont += Configs.FASE;
		System.Random rng = new System.Random ();
		_sujeiras = _sujeiras.OrderBy (x => rng.Next ()).ToList();
		if (_cont > _sujeiras.Count) {
			_cont = _sujeiras.Count;
		}

		for(int i = 0; i<_cont;i++){
			_sujeiras[i].SetActive(true);
		}
	}

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

	public void ContarSujeira(){
		_cont -= 1;
		if (_cont == 0) {
			Ganhar ();
		}
	}


}
