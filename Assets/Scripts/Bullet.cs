using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Logic ----
    public int dmg;

    //Methods ----
    private void Start()
    {
        dmg = 20;
    }

    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
