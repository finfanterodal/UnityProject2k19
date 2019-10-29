using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	//Indice del Array de puntos
	private int wayPointsIndice;
	//Array con los puntos para el movimiento automatico del enemigo
	[SerializeField]
	private Transform [] wayPoints;
	private Vector3 targetPosition;

	[SerializeField]
	[Range(0,1f)] //Ponemos un slider para regular la velocidad del enemigo
	private float vmovimiento;
	//Inicializacion
	void Start () 
	{
		//Posicionarse en el primer punto al ejecutar
		targetPosition = wayPoints[0].position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Posicionarse de un punto a otro 
		//Con el método MoveTowars, coge la posición actual, nuestra posición destino y su velocidad
		transform.position = Vector3.MoveTowards(transform.position,targetPosition,0.5f*vmovimiento);
		//Comparamos si la distancia actual es menos que una que determinamos para ya, cargar el siguiente punto al que ir.
		if(Vector3.Distance(transform.position,targetPosition)<0.3f)
		{
			if (wayPointsIndice >= wayPoints.Length-1)
			{
				wayPointsIndice=0;
			}
			else
			{
				wayPointsIndice++;
			}
			targetPosition= wayPoints[wayPointsIndice].position;
		}
	}
}
