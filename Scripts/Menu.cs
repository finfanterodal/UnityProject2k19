using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Clase para controlar el menu con la tecla Escape asignada a Cancel
public class Menu : MonoBehaviour {
	private GameObject menu;

	//Inicializacion
	void Start () {
		menu = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetButtonDown("Cancel"))
		{
			menu.SetActive(!menu.activeSelf);
		}
	}
}
