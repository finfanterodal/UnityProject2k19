 using UnityEngine;
 using UnityEngine.AI;
//Clas para el control del enemigo en el nivel-2, y el animator
public class Moveto : MonoBehaviour {

   public Transform goal;
   private NavMeshAgent agent;
   public float proximidad;
   public Animator animat;  
    void Start () 
       {
            agent = GetComponent<NavMeshAgent>();
            animat = goal.GetComponent<Animator>();
       }

    void Update()
        {
                agent.SetDestination(goal.position);
                if (!agent.pathPending && agent.remainingDistance < proximidad)
            {
                Debug.Log("Peligro");
                animat.SetBool("Estar_en_Peligro", true);
            }
            else
            {
                Debug.Log("Tranqui");
                animat.SetBool("Estar_en_Peligro", false);
            }
        }
}
