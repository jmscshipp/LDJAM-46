using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionManager : MonoBehaviour
{
    public Animator cameraAnimator;
    public Animator canvasAnimator;
    private enum State { creature, potion, electric, talking, attachment}; // talking yet to be implimented
    private State currentState = State.creature;

    // functions to be called by UI buttons to control camera
    public void ReturnToCreature()
    {
        if (currentState != State.creature)
        {
            cameraAnimator.SetBool("toPotion", false);
            cameraAnimator.SetBool("toElectric", false);
            canvasAnimator.SetBool("toPotion", false);
            canvasAnimator.SetBool("toElectric", false);
            cameraAnimator.SetBool("toAttachment", false);
            canvasAnimator.SetBool("toAttachment", false);
            currentState = State.creature;
        }
    }
    public void GoToPotion()
    {
        if (currentState == State.creature)
        {
            cameraAnimator.SetBool("toPotion", true);
            canvasAnimator.SetBool("toPotion", true);
            currentState = State.potion;
        }
    }
    public void GoToElectric()
    {
        if (currentState == State.creature)
        {
            cameraAnimator.SetBool("toElectric", true);
            canvasAnimator.SetBool("toElectric", true);
            currentState = State.electric;
        }
    }
    public void GoToFace()
    {
        cameraAnimator.SetBool("final", true);
        canvasAnimator.SetBool("final", true);
    }
    public void GoToAttachment()
    {
        if (currentState == State.creature)
        {
            cameraAnimator.SetBool("toAttachment", true);
            canvasAnimator.SetBool("toAttachment", true);
            currentState = State.attachment;
        }
    }
}
