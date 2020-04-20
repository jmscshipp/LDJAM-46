using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyPart : MonoBehaviour
{
    public Transform goalPosition;

    public void Move()
    {
        transform.position = goalPosition.position;
        transform.rotation = goalPosition.rotation;
        GetComponent<BoxCollider>().enabled = false;
    }
}
