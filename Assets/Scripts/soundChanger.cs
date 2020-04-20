using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundChanger : MonoBehaviour
{
    private float timeCount = 0f;

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= 4)
        {
            ChangeSound();
            timeCount = 0f;
        }
    }

    private void ChangeSound()
    {
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
    }
}
