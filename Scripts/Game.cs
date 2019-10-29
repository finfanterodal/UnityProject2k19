using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
	[SerializeField]
	private int nivel;
	private int masNivel;
	[SerializeField]
	private bool nivelFinal;
	// Use this for initialization
	void Start () {
		masNivel=nivel+1;
	}
	//Método para Cargar el nivel y que quede más encapsulado y se pueda acceder desde fuera a él
	public void cargarNivel(string nombreNivel){
		SceneManager.LoadScene(nombreNivel);
	}


	//
	public void cargarSiguienteNivel()
	{
		//Utilizamos el Manager para cargar las escenas, importando UnityEngine.SceneManagement nos ahorramos algo de código
		if (!nivelFinal)
		{
			string nombreScene = "Level-"+masNivel;
			cargarNivel(nombreScene);
		}else 
		{
			//menu inicial
			cargarNivel("Menu-Principal");
		}
	}
	//Cuando un enemigo nos caza reiniciamos la scene
	public void reiniciarNivel()
	{
		cargarNivel("Level-"+nivel);
	}

	//Salir dell juego
	public void salir(){
		//Métopdo quit de la clase Application para salir del juego
		Application.Quit();
	}


}
