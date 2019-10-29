using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Clase para controlar el seguimiento de la cámara al player
public class CameraController : MonoBehaviour {
	
	public GameObject player;
	private Vector3 offset;
	//Inicializacion
	void Start () 
	{
		offset = transform.position;
	}
	
	//Seguimiento de la cámara al player
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
	}
}
