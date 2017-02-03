using UnityEngine;
using System.Collections;

public class PontoPercurso : MonoBehaviour {

	Percurso _percurso;

	// Use this for initialization
	void Start () {
		_percurso = transform.parent.GetComponent<Percurso> ();
	}


	void OnMouseEnter(){
		if (_percurso != null) {
			if (_percurso.ContaNo (transform.GetSiblingIndex ())) {
				/*
				GetComponent<SpriteRenderer> ().color = Color.red;
				GetComponent<BoxCollider2D> ().enabled = false;
				*/
				gameObject.SetActive (false);

			}
		}
	}

}
