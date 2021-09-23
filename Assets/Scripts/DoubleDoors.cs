using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoors : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public AudioSource leftDoorSound;
    public AudioSource rightDoorSound;
    private float leftOpenPos;
    private float rightOpenPos;
    private float leftClosedPos;
    private float rightClosedPos;
    private bool doorOpen;
    private float speed = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        leftClosedPos = leftDoor.transform.position.x;
        rightClosedPos = rightDoor.transform.position.x;
        leftOpenPos = leftClosedPos - leftDoor.transform.localScale.x;
        rightOpenPos = rightClosedPos + rightDoor.transform.localScale.x;
        leftDoorSound.Stop();
        rightDoorSound.Stop();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (doorOpen == false)
        {
            rightDoorSound.Stop();
            leftDoorSound.Stop();
        }
        doorOpen = true;
        rightDoorSound.Play();
        leftDoorSound.Play();
    }
    public void OnTriggerExit(Collider other)
    {
        if (doorOpen == true)
        {
            rightDoorSound.Stop();
            leftDoorSound.Stop();
        }
        doorOpen = false;
        rightDoorSound.Play();
        leftDoorSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(doorOpen);
        if (doorOpen == true)
        {
            if (leftDoor.transform.position.x >= leftOpenPos)
            {
                leftDoor.transform.Translate(-(speed * Time.deltaTime), 0f, 0f, Space.Self);
            }
            if (rightDoor.transform.position.x <= rightOpenPos)
            {
                rightDoor.transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.Self);
            }
        }
        if (doorOpen == false)
        {
            if (leftDoor.transform.position.x <= leftClosedPos)
            {
                leftDoor.transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.Self);
            }
            if (rightDoor.transform.position.x >= rightClosedPos)
            {
                rightDoor.transform.Translate(-(speed * Time.deltaTime), 0f, 0f, Space.Self);
            }
        }
    }
}
