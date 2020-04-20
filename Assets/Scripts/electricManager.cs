using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricManager : MonoBehaviour
{
    public taskManager manager;
    public int[] combo = new int[4]; // the goal combination of switches
    public int[] switches = new int[4]; // current arrangement of switches
    public GameObject[] buttonObjects = new GameObject[4];
    public string formattedGoalCombo = ""; // to be picked up by electric text and fed into UI
    public GameObject[] switchObjects = new GameObject[4]; // for resetting animations
    public Material redMat;
    public Material greenMat;

    // Start is called before the first frame update
    void Start()
    {
        combo = Scramble();
        switches = ResetSwitches();
    }

    // called by switches and sent here to activate lights and check against combo
    public void Activate(int switchIndex)
    {
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        GetComponent<AudioSource>().Play();
        if (switches[switchIndex] == 1)
        {
            switches[switchIndex] = 0;
        }
        else
        {
            switches[switchIndex] = 1;
            if (combo[switchIndex] != 1)
            {
                // bad stuff happens
            }
        }
        UpdateSwitches();
    }

    public void Reset()
    {
        combo = Scramble();
        switches = ResetSwitches();
    }

    private void UpdateSwitches()
    {/*
        for (int i = 0; i < 4; i ++)
        {
            if (switchObjects[i].GetComponent<switchScript>().active == true)
                switchObjects[i].GetComponent<switchScript>().button.GetComponent<MeshRenderer>().material = greenMat;
            else
                switchObjects[i].GetComponent<switchScript>().button.GetComponent<MeshRenderer>().material = redMat;
        }*/
        if (arraysAreSame())
        {
            manager.ElectricDone();
            formattedGoalCombo = "--complete--";
        }
    }

    private bool arraysAreSame()
    {
        bool identical = true;
        for (int i = 0; i < 4; i++)
        {
            if (combo[i] != switches[i])
            {
                identical = false;
            }
        }
        return identical;
    }

    private int[] Scramble()
    {
        int[] tempCombo = new int[4];
        string newGoal = "";
        for (int i = 0; i < 4; i++)
        {
            int value = (int)Mathf.Round(Random.Range(0f, 1f));
            tempCombo[i] = value;
        }
        bool allUp = true;
        for (int i = 0; i < 4; i++)
        {
            int value = tempCombo[i];
            if (value != 0)
            {
                allUp = false;
            }
        }
        if (allUp == true)
        {
            tempCombo[(int)Mathf.Round(Random.Range(0f, 3f))] = 1;
        }
        for (int i = 0; i < 4; i++)
        {
            if (tempCombo[i] == 1)
                newGoal += "O ";
            else
                newGoal += "- ";
        }
        formattedGoalCombo = newGoal;
        return tempCombo;
    }

    private int[] ResetSwitches()
    {
        int[] tempSwitches = new int[4];
        for (int i = 0; i < 4; i++)
        {
            tempSwitches[i] = 0;
            switchObjects[i].GetComponent<switchScript>().active = false;
            switchObjects[i].GetComponent<Animator>().SetBool("activate", false);
            buttonObjects[i].GetComponent<MeshRenderer>().material = redMat;
        }
        return tempSwitches;
    }
}
