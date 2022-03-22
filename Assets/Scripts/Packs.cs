using UnityEngine;
using UnityEngine.UI;

public class Packs : MonoBehaviour
{
    //Constants ----
    private const int BasicHpPack = 100;
    private const int BasicAmmoPack = 20;

    //Game objects / logic ----
    private Text ammoText;

    //Methods ----
    private void Start()
    {
        ammoText = GameObject.Find("/Canvas/Ammo").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("Player") )
        {
            var player = other.gameObject.GetComponent<Player>();
            if (gameObject.tag.Equals("HpPack") && player.currHealth < player.health)
            {
                AudioManager.Instance.Play("HealPickUp");
                if ((player.currHealth + BasicHpPack) > player.health)
                {
                    player.AddHp(player.health - player.currHealth);
                }
                else
                {
                    player.AddHp(BasicHpPack);
                }
                Destroy(gameObject);
            }

            if (gameObject.tag.Equals("APack"))
            { 
                AudioManager.Instance.Play("AmmoPickUp");
                player.GetComponentInChildren<WeaponBehaviour>().AddAmmo(BasicAmmoPack);
                ammoText.text = "Ammo : " + player.GetComponentInChildren<WeaponBehaviour>().totalB;
                Destroy(gameObject);
            }

        }
    }
}
