using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
    public bool active = false;
    public int num;
    public electricManager manager;
    public GameObject button;
    public Material redMat;
    public Material greenMat;

    public void Activate()
    {
        manager.Activate(num);
        if (active == false)
        {
            GetComponent<Animator>().SetBool("activate", true);
            button.GetComponent<MeshRenderer>().material = greenMat;
            active = true;
        }
        else
        {
            GetComponent<Animator>().SetBool("activate", false);
            button.GetComponent<MeshRenderer>().material = redMat;
            active = false;
        }
    }
}
