using UnityEngine;
using System.Collections;

public class MinigameEsperar : Minigame {

	public SpriteRenderer _semaforo;
	public Sprite _semaforoVerde;
	public Transform _saida;
	public Transform _carro;
	public float _velocidadeCarro;
	public GameObject _imagemDerrota;


	protected override void AcabarTempo ()
	{
		base.AcabarTempo ();
		_semaforo.sprite = _semaforoVerde;
		Ganhar ();
	}

	protected override void Update ()
	{
		base.Update ();
		if (!_rodando) {
			return;
		}
		if (Input.GetMouseButtonDown (0)) {
			Perder ();
		}
	}

	protected override IEnumerator RotinaVitoria ()
	{


		while (_carro.localPosition.y < _saida.localPosition.y) {
			_carro.localPosition += Vector3.up * _velocidadeCarro * Time.deltaTime;
			yield return null;
		}

		yield return base.RotinaVitoria ();
	}

	protected override IEnumerator RotinaDerrota ()
	{

		while (_carro.localPosition.y < _saida.localPosition.y) {
			_carro.localPosition += Vector3.up * _velocidadeCarro * Time.deltaTime;
			yield return null;
		}

		_imagemDerrota.SetActive (true);

		yield return new WaitForSeconds (0.5f);

		yield return base.RotinaDerrota ();
	}


}
