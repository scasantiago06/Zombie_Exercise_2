using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassController : MonoBehaviour                                                                    //Esta clase se encarga de hacer las instancias.
{   /*
    WaitForSeconds waitSeconds = new WaitForSeconds(0.3f);                                                      //Defino una variable "WaitForSeconds" para no tener que crear nuevas en cada repetición.
    int calls;                                                                                                  //Creo un "int" llamado "calls".
    int whichInstance;                                                                                          //Creo un "int" llamado "whichInstance".
    int j;                                                                                                      //Creo un "int" llamado "j".
    int ages;                                                                                                   //Creo un "int" llamado "ages".
    string[] names = new string[]                                                                               //Creo una matriz donde guardo en las próximas dos líneas 20 nombres para después acceder a ellos.
    {
        "Stubbs", "Rob", "Rodolfo", "Arnulfo", "Jesús", "Cristian", "Santiago", "Alonso", "Dios", "Samuel",     //En esta línea y la siguiente esta la lista de nombres que se utilizarón
        "Ricardo", "José", "Armando", "Luna", "María", "Mónica", "Manuela", "Cristobal", "Furgo", "Andrés"      //para darle nombres a los ciudadanos.
    };

    void Start ()                                                                                               //Uso la función "Start" para lo siguiente:
    {
        new Hero();                                                                                             //Instancio el constructor de la clase "Hero".
        calls = Random.Range(4, 10);                                                                            //La variable "calls" la inicializo como un "Random" entre 4 Y 9 (Recordemos que el último dígito no se cuenta) 
        StartCoroutine("Instances");                                                                            //Inicio la corrutina "Instances".
    }

    IEnumerator Instances()                                                                                     //En la corrutina ocurre lo siguiente:
    {
        yield return waitSeconds;                                                                               //Espero los segundos declarados con la variable "waitSeconds", es decir, 0.3.

        for (int i = 0; i < calls; i++)                                                                         //Este ciclo controla la cantidad de instancias que habrá, el ejercicio dice que entre 5 y 10 instancias, y el héroe cuenta como una, así que por eso el bucle se límita con la variable "calls" que se declaró entre 4 y 10.
        {
            whichInstance = Random.Range(1, 3);                                                                 //Esta variable se utiliza como la que define que instancia se hace, es decir, si se instancia "Zombie" o "Citizen", y como tiene que ser aleatoriamente por eso se define como una variable que puede llegar a valer 1 o 2.
            ages = Random.Range(15,101);                                                                        //"ages" es un valor "Random" que se utilizará como argumento para que nos de unm valor que será la edad del ciudadano.
            j = Random.Range(0, names.Length);                                                                  //"j" es otro valor "Random" que también se utilizará como argumento y el valor va desde 0 hasta el largo de la matríz de nombres, en este caso 20.

            if (whichInstance == 1)                                                                             //El condicional es para saber que número nos arrojó "whichInstance" entrará o no en esto.
            {
                new Zombie();                                                                                   //Si el valor de "whichInstance" es 1, instancia un Zombie.
            }
            else                                                                                                //Si no:
            {
                new Citizen(names[j], ages);                                                                    //Si el valor de "whichInstance" es 2, instancia un Ciudadano.
            }
        }
    }
    */
    int numberOfCubes;
    int randomComponent;
    bool HeroCreated;
    Vector3 randomPosition;
    Rigidbody rb;

    private void Start()
    {
        numberOfCubes = Random.Range(10, 21);

        for (int i = 0; i <= numberOfCubes; i++)
        {
            randomPosition = new Vector3(Random.Range(0, 30), 0, Random.Range(0, 30));

            if (HeroCreated == false)
            {
                randomComponent = Random.Range(0, 3);
            }
            else
            {
                randomComponent = Random.Range(1, 3);
            }

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = randomPosition;

            if (randomComponent == 0 && HeroCreated == false)
            {
                go.AddComponent<Hero>();
                go.AddComponent<Rigidbody>();
                rb = go.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                HeroCreated = true;
            }
            else if (randomComponent == 1)
            {
                go.AddComponent<Zombie>();
            }
            else if (randomComponent == 2)
            {
                go.AddComponent<Citizen>();
                go.name = "Citizen";
            }
        }
    }
}