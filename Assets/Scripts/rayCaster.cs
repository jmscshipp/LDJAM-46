using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCaster : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    public potionManager potionManager;
    public taskManager taskManager;

    private int armCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.collider.tag == "Ingrediant")
                {
                    potionManager.AddIngrediant(hit.collider.gameObject.GetComponent<spawner>().prefabToSpawn);
                }
                if (hit.collider.tag == "Switch")
                {
                    hit.collider.gameObject.GetComponent<switchScript>().Activate();
                }
                if (hit.collider.tag == "Head") 
                {
                    GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
                    GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.GetComponent<bodyPart>().Move();
                    taskManager.BodypartDone();
                }
                if (hit.collider.tag == "Arm1")
                {
                    GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
                    GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.GetComponent<bodyPart>().Move();
                    armCount++;
                    if (armCount >= 2)
                    {
                        taskManager.BodypartDone();
                    }
                }
                if (hit.collider.tag == "Arm2")
                {
                    GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
                    GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.GetComponent<bodyPart>().Move();
                    armCount++;
                    if (armCount >= 2)
                    {
                        taskManager.BodypartDone();
                    }
                }
                if (hit.collider.tag == "Heart")
                {
                    GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
                    GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.GetComponent<bodyPart>().Move();
                    taskManager.BodypartDone();
                }
            }  
        }
    }
}
