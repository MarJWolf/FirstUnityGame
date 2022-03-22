using UnityEngine;
public class Teleport : MonoBehaviour
{
    //Methods ----
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.position = transform.GetChild(0).gameObject.transform.position;
        }
    }
}
