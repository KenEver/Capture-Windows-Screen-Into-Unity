using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_physic : MonoBehaviour
{
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        cc.Move(Physics.gravity * Time.deltaTime);
    }
}
