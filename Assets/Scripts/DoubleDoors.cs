using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoors : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    private float leftOpenPos;
    private float rightOpenPos;
    private float leftClosedPos;
    private float rightClosedPos;
    private bool doorOpen;
    private int speed;
    private float myLeftX;
    private float myRightX;

    // Start is called before the first frame update
    void Start()
    {
        leftClosedPos = leftDoor.transform.position.x;
        rightClosedPos = rightDoor.transform.position.x;
        leftOpenPos = leftClosedPos - leftDoor.transform.localScale.x;
        rightOpenPos = rightClosedPos + rightDoor.transform.localScale.x;
    }

    public void OnTriggerEnter(Collider other)
    {
        doorOpen = true;
    }
    public void OnTriggerExit(Collider other)
    {
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(doorOpen);
        if (doorOpen == true)
        {
            
            if (leftDoor.transform.position.x <= leftOpenPos)
            {
                //stop
            }
            else
            {
                leftDoor.transform.Translate(Vector3.left * Time.deltaTime, Space.Self);
            }
            if (rightDoor.transform.position.x >= rightOpenPos)
            {
                //stop
            }
            else
            {
                rightDoor.transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
            }
        }
        if (doorOpen == false)
        {
            if (leftDoor.transform.position.x >= leftClosedPos)
            {
                //stop
            }
            else
            {
                leftDoor.transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
            }
            if (rightDoor.transform.position.x <= rightClosedPos)
            {
                //stop
            }
            else
            {
                rightDoor.transform.Translate(Vector3.left * Time.deltaTime, Space.Self);
            }
        }
        //leftDoor.transform.position = new Vector3(myLeftX, leftDoor.transform.position.y, leftDoor.transform.position.z);
        //rightDoor.transform.position = new Vector3(myRightX, rightDoor.transform.position.y, rightDoor.transform.position.z);
    }
}
