using UnityEngine;

public class Key : MonoBehaviour
{
    //Methods ----
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            AudioManager.Instance.Play("KeyPickUp");
            collision.gameObject.GetComponent<Player>().keys++;
            collision.gameObject.GetComponent<Player>().keyText.text = "Keys : " + collision.gameObject.GetComponent<Player>().keys + "/" + collision.gameObject.GetComponent<Player>().keysReq;
            Destroy(gameObject);
        }
    }
}
