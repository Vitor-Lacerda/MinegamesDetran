using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CriadorPista : MonoBehaviour {


	public GameObject _prefabPista;
	public float _yOffset = 32.5f;
	public bool _rodando;
	Minigame _minigame;



	protected List<GameObject> _listaPistas;

	GameObject _pistaMaisLonge;
	// Use this for initialization
	void Start () {
		_minigame = transform.parent.GetComponent<Minigame> ();
		_listaPistas = new List<GameObject> ();
		foreach (Pista p in transform.GetComponentsInChildren<Pista>(true)) {
			_listaPistas.Add (p.gameObject);
		}

		_pistaMaisLonge = _listaPistas.OrderByDescending (p => p.transform.position.y).First ();
	
	}

	void Update(){
		_rodando = _minigame._rodando;
	}

	protected GameObject CriarOuAcharObjeto(){
		GameObject novoObjeto = null;

		foreach (GameObject p in _listaPistas) {
			if (p.activeSelf == false) {
				novoObjeto = p;
				break;
			}
		}

		if (novoObjeto == null) {
			novoObjeto = Instantiate (_prefabPista) as GameObject;
			_listaPistas.Add (novoObjeto);
		}


		return novoObjeto;

	}
	
	public virtual void CriarNovaPista(){
		GameObject novaPista = CriarOuAcharObjeto();
		novaPista.transform.parent = this.transform;
		novaPista.transform.localPosition = new Vector2 (_pistaMaisLonge.transform.localPosition.x, _pistaMaisLonge.transform.localPosition.y + _yOffset);
		novaPista.SetActive (true);
		_pistaMaisLonge = novaPista;
	}
}
