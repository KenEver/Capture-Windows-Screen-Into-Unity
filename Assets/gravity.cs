using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    public float gravityNum = -9.81f;
    private Vector3 fallingspeed;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //REeset the MoveVector
        fallingspeed = new Vector3(0,0,0);

        //Check if character is grounded
        if (controller.isGrounded == false)
        {
            //gravityNum *= Time.deltaTime;
            //Add our gravity Vecotr
            fallingspeed += new Vector3(0, gravityNum * Time.deltaTime, 0);
        }

        //Apply our move Vector , remeber to multiply by Time.delta
        //controller.Move(fallingspeed );
    }
}
