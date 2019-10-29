using UnityEngine;

public class Player : MonoBehaviour {
	

	//Variable para poder utyilizar el método de nuestro Script de reiniciar nivel
	[SerializeField]
	private Game juego;
	//Referencia al Player
	[SerializeField]
	private Rigidbody playerBody;
	private bool jump;
	private bool isGrounded;
	private Vector3 inputVector;
	[SerializeField]
	private int monedas;

	[SerializeField]
	private TMPro.TextMeshProUGUI monedaText;
	// Use this for initialization
	void Start () {
		//Para buscar el objeto Game y utilizar su método si tener que crear una variable pública
		//game = FindObjectOfType<Game>();
		//Recogemos el RIgibody del player 
		playerBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {	
		inputVector = new Vector3(Input.GetAxis("Horizontal")*10f, playerBody.velocity.y,Input.GetAxis("Vertical")*10f);
		//Método que hace que al girar. se mantenga en una determinada posicióin
		transform.LookAt(transform.position+new Vector3(inputVector.x,0,inputVector.z));
		//Comprobamos cada frame si se pulsa el botón 
		if (Input.GetButtonDown("Jump")&&isGrounded)
		{
			jump=true;
		}
	}


	//Se ejecuta..
	private void FixedUpdate() {
		playerBody.velocity = inputVector;
		// Aplicamos la física
		if(jump && isGrounded){
			//Al cambiar la masa del player tendremos que añadir másfuerza para que salte
			playerBody.AddForce(Vector3.up*20f, ForceMode.Impulse);
			jump=false;
			isGrounded = false;
		}
	}

	//OnCollisionEnter es llamado cada vez que un Rigidbody/Collaider está en contacto con otro.
    private void OnCollisionEnter(Collision col) //COllision nos da información sobre la colision
    {
		//Comprobamos si está en el suelo para poder saltar, de modo contrario será imposible, utilizando Gr
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }

		//Comprobamos si se colisiona con el enemigo comparando con  la Etiqueta del objheto con el que chocamos
		if (col.gameObject.tag == ("Enemy")){
			juego.reiniciarNivel();
		}
    }

	//Con el istrigger de la mondeda seleccionado podemos atravesarla, 
	//y no colisionar físicamente para poder coleccionarla
	 private void OnTriggerEnter(Collider other)//Collider nos da la referencia del objeto con el cual colisionamos
	 {
		switch (other.tag)
		{
			case "Coin":
				//Aumentamos el numero de moneditas y lo escribimos en la interfaz
				monedas++;
				other.gameObject.SetActive(false);
				//Introducimos el texto con este formato en el TExtPro
				monedaText.text=string.Format("Monedas\n{0}",monedas);
				break;
			case "Goal":
				//Si llegamos a la zona verde, chequeamos que tengamos las monedas necesario
				if(monedas >= GameObject.FindGameObjectsWithTag("Coin").Length-1){
					juego.cargarSiguienteNivel();
				}else{
					Debug.Log("No tienes suficientes monedas");
				}
				break;
			default:
				break;
		}
	 }
}
 