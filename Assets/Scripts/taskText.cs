using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taskText : MonoBehaviour
{
    public taskManager manager;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = manager.formattedTasks;
    }
}
