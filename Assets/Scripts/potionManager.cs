using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionManager : MonoBehaviour
{
    public taskManager manager;
    //"frog", "honeycomb", "rock salt"
    private string[] ingrediantNames = new string[] { "eyeball", "mushroom", "hemlock", "sassafras", "ginger", "gem"}; // will edit later to make more model-able

    // current ingrediant stuff
    private List<string> ingrediants = new List<string>();
    private List<int> ingrediantNums = new List<int>();
    public string formattedRecipe = "";

    // Start is called before the first frame update
    void Start()
    {
        NewRecipe(3);
    }

    // called when the player clicks on a physical ingrediant in the potion area
    public void AddIngrediant(GameObject ingrediant)
    {
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        GetComponent<AudioSource>().Play();
        GameObject newIngrediant;
        newIngrediant = Instantiate(ingrediant, transform.position, Random.rotation);
        int spaceFlagger = ingrediant.name.Length;
        for (int i = 0; i < ingrediant.name.Length; i++)
        {
            if (ingrediant.name[i] == ' ')
            {
                spaceFlagger = i;
                break;
            }
        }
        newIngrediant.name = newIngrediant.name.Substring(0, spaceFlagger);
        if (newIngrediant.name == "hemlock" || newIngrediant.name == "sassafras")
        {
            newIngrediant.transform.rotation = Quaternion.Euler(-90f, 0f, -90f);
            Debug.Log("blah");
        }
        if (ingrediants.Contains(ingrediant.name))
        {
            int index = ingrediants.IndexOf(ingrediant.name);
            ingrediantNums[index] = ingrediantNums[index] - 1;
            if(ingrediantNums[index] == 0)
            {
                ingrediants.Remove(ingrediants[index]);
                ingrediantNums.Remove(ingrediantNums[index]);
            }
            formattedRecipe = "";
            for (int i = 0; i < ingrediants.Count; i++)
            {
                if (i == 0)
                    formattedRecipe += ingrediantNums[i] + " x " + ingrediants[i];
                else
                    formattedRecipe += "\n" + ingrediantNums[i] + " x " + ingrediants[i];
            }
            if (ingrediants.Count == 0)
            {
                manager.PotionDone();
                formattedRecipe = "--complete--";
            }
        }
        else
        {
            // the potion is bad
        }
    }

    public void NewRecipe(int ingrediantNum)
    {
        ingrediants = new List<string>(); // clearing out lists
        ingrediantNums = new List<int>();
        formattedRecipe = "";

        for (int i = 0; i < ingrediantNum; i++)
        {
            ingrediants.Add(ChooseIngrediant());
            ingrediantNums.Add((int)Mathf.Round(Random.Range(1f, 4f)));
        }
        for (int i = 0; i < ingrediants.Count; i++)
        {
            if (i == 0)
                formattedRecipe += ingrediantNums[i] + " x " + ingrediants[i];
            else
                formattedRecipe += "\n" + ingrediantNums[i] + " x " + ingrediants[i];
        }
    }

    private string ChooseIngrediant()
    {
        string name = ingrediantNames[(int)Mathf.Round(Random.Range(0f, ingrediantNames.Length - 1))];
        if (ingrediants.Contains(name))
        {
            name = ChooseIngrediant();
        }
        return name;
    }
}
