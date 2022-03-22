using UnityEngine;

public class Fireball : MonoBehaviour
{
    //Logic ----
    public int dmg;

    //Methods----
    private void Start()
    {
        dmg = 120;
    }

    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
