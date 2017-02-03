using UnityEngine;
using System.Collections;

public class MinigameAbrirCaminho : Minigame {

	public int _contCarros = 6;
	public AmbulanciaAbrirCaminho _ambulancia;

	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		if (_contCarros == 0) {
			Ganhar ();
		} else {
			Perder ();
		}
	}

	protected override IEnumerator RotinaDerrota ()
	{
		_ambulancia._movendo = true;

		yield return new WaitForSeconds(2f);

		yield return base.RotinaDerrota ();
	}

	protected override IEnumerator RotinaVitoria ()
	{
		_ambulancia._movendo = true;

		yield return new WaitForSeconds(2f);

		yield return base.RotinaVitoria ();
	}

	public void ContarCarro(){
		_contCarros -= 1;
		if (_contCarros == 0) {
			Ganhar ();
		}
	}

}
