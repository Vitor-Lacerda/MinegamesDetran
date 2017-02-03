using UnityEngine;
using System.Collections;

public class MinigameMacaco : Minigame {

	public GameObject _barrinha;
	public GameObject _setinha;
	public Animator _animFundo;


	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		Perder ();
	}



	protected override IEnumerator RotinaVitoria ()
	{
		_rodando = false;
		_barrinha.SetActive (false);
		_setinha.SetActive (false);

		_animFundo.SetInteger ("Vitoria", 1);

		yield return new WaitForSeconds (2f);

		yield return base.RotinaVitoria ();
	}

	protected override IEnumerator RotinaDerrota ()
	{
		_rodando = false;
		_barrinha.SetActive (false);
		_setinha.SetActive (false);

		_animFundo.SetInteger ("Vitoria", -1);

		yield return new WaitForSeconds (2f);

		yield return base.RotinaDerrota ();
	}

}
