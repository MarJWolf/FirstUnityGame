using System;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    //Methods ----
    private void OnTriggerStay(Collider other)
    {
        GetComponentInParent<Player>().canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<Player>().canJump = false;
    }
}
