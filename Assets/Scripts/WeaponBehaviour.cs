using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponBehaviour : MonoBehaviour
{
    //Game objects / logic ----
    public GameObject bulletPf;
    public int totalB;
    public GameObject pos;
    public Text ammoText;

    //Methods ----
    void Start()
    {
        totalB = 200;
        ammoText.text = "Ammo : " + totalB;
    }

    public void OnShoot()
    {
        totalB--;
        GameObject bullet = Instantiate(bulletPf, pos.transform.position, pos.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(pos.transform.up * 3000);
        ammoText.text = "Ammo : " + totalB;
        
    }

    public void AddAmmo(int ammo)
    {
        totalB += ammo;
    }
}
