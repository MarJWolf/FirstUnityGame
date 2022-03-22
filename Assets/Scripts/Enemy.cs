using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //Constants ----
    const int Damage = 50;

    //Game objects / logic ----
    private GameObject _cubeP;
    public GameObject fireballPf;
    public GameObject position;
    private int _health;
    private float _speed;
    private float waitTime = 5.0f;
    private float _timer;

    //Methods ----
    void Start()
    {
        _health = 100;
        _cubeP = GameObject.FindGameObjectWithTag("Player");
        _speed = 0.003f;
        _timer = 0.0f;
        GetComponentInChildren<Slider>().maxValue = _health;
        GetComponentInChildren<Slider>().value = _health;
    }

    void Update()
    {
        var cpos = _cubeP.transform.position;
        Vector3 pos = new Vector3(cpos.x, 0.5f,cpos.z);
        transform.position = Vector3.MoveTowards(transform.position, pos, _speed);
        if (_health <= 1) {
            _cubeP.GetComponent<Player>().AddPoint(5);
            Destroy(this.gameObject);
        }

        if (gameObject.CompareTag("EnemyR"))
        {
            _timer += Time.deltaTime;
            if (_timer > waitTime)
            {
                _timer = _timer - waitTime;
                Shoot();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) {
            Hurt(collision.collider.gameObject.GetComponent<Bullet>().dmg);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("EnemyM"))
            {
                AudioManager.Instance.Play("EnemyHit");
                collision.collider.gameObject.GetComponent<Player>().Hit(Damage);
            }
            _cubeP.GetComponent<Rigidbody>().AddForce((_cubeP.transform.position - position.transform.position) * 500);
        }

    }

    public void Hurt(int dmg) {
        _health -= dmg;
        GetComponentInChildren<Slider>().value = _health;
    }

    void Shoot()
    {
        Vector3 rotation = transform.eulerAngles;
        GameObject fireball = Instantiate(fireballPf, position.transform.position, position.transform.rotation);
        fireball.transform.eulerAngles = new Vector3(rotation.x - 90, rotation.y + 130, rotation.z);
        fireball.GetComponent<Rigidbody>().AddForce((_cubeP.transform.position - transform.position) * 200);
    }

}

