using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recipeText : MonoBehaviour
{
    public potionManager manager;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = manager.formattedRecipe;
    }
}
