using UnityEngine;

public class Hammer : MonoBehaviour
{
    //Logic ----
    private int dmg = 200;

    //Methods ----
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyM") || collision.gameObject.CompareTag("EnemyR"))
        {
            collision.collider.gameObject.GetComponent<Enemy>().Hurt(dmg);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<Player>().Hit(dmg);
        }

        Destroy(this.gameObject);
    }
}
