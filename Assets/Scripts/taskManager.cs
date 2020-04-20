using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class taskManager : MonoBehaviour
{
    private enum Stage { head, arms, heart };
    private Stage currentStage = Stage.head;
    private string[] tasks = new string[4] { "", "", "", "" };
    public GameObject accessBodyButton, head, arm1, arm2, heart;

    public transitionManager transitionManager;
    public potionManager potionManager;
    public electricManager electricManager;

    public string formattedTasks = ""; // to be sent to UI text for display
    public GameObject face;
    public Material newFaceMat;

    // Start is called before the first frame update
    void Start()
    {
        UpdateStage(Stage.head);
    }

    private void Update()
    {
        formattedTasks = tasks[0] + tasks[1] + tasks[2] + tasks[3];
    }

    // called when tasks are done to update task list
    public void PotionDone()
    {
        tasks[0] = "";
        CheckIfReady();
    }
    public void ElectricDone()
    {
        tasks[1] = "";
        CheckIfReady();
    }
    public void ConvoDone()
    {
        tasks[3] = "";
        CheckIfReady();
    }
    public void BodypartDone()
    {
        if (currentStage == Stage.head)
        {
            tasks[3] = "";
            UpdateStage(Stage.arms);
        }
        else if (currentStage == Stage.arms)
        {
            tasks[3] = "";
            UpdateStage(Stage.heart);
        }
        else if (currentStage == Stage.heart)
        {
            tasks[3] = "";
            transitionManager.GoToFace();
            StartCoroutine(EndGame());
        }
    }

    private void CheckIfReady() // called when a task is completed to see if its time for body part attachment
    {
        if (tasks[0] == "" && tasks[1] == "" && tasks[2] == "")
        {
            accessBodyButton.SetActive(true);
            if (currentStage == Stage.head)
            {
                head.GetComponent<BoxCollider>().enabled = true;
            }
            else if (currentStage == Stage.arms) // ADD THIS STUFF IN LATER
            {
                arm1.GetComponent<BoxCollider>().enabled = true;
                arm2.GetComponent<BoxCollider>().enabled = true;
            }
            else if (currentStage == Stage.heart)
            {
                heart.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    // called to reset task list when a stage is complete
    private void UpdateStage(Stage newStage) // takes in the stage being switched to
    {
        if (newStage == Stage.head)
        {
            tasks[0] = "-Feed IT a potion\n";
            tasks[1] = "-Prime IT with electricity\n";
            tasks[3] = "-When IT is ready... attach ITs head\n";
        }
        if (newStage == Stage.arms)
        {
            tasks[0] = "-Feed IT a potion\n";
            tasks[1] = "-Prime IT with electricity\n";
            //tasks[2] = "-Have a conversation with IT\n"; holding off on this until there's extra time
            tasks[3] = "-When IT is ready... attach ITs arms";
            currentStage = Stage.arms;
            potionManager.NewRecipe(4);
        }
        if (newStage == Stage.heart)
        {
            tasks[0] = "-Feed IT a potion\n";
            tasks[1] = "-Prime IT with electricity\n";
            //tasks[2] = "-Have a conversation with IT\n";
            tasks[3] = "-When IT is ready... plug in ITs heart";
            currentStage = Stage.heart;
            potionManager.NewRecipe(5);
        }
        accessBodyButton.SetActive(false);
        electricManager.Reset();
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
        face.GetComponent<MeshRenderer>().material = newFaceMat;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }

}
