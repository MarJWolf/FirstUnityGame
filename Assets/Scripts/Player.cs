using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Game objects / logic ----
    public GameObject enemyPf;
    public float mThrust;
    private static int _score;
    public Text scoreText;
    public Text keyText;
    public Text healthText;
    public int health;
    public int currHealth;
    public bool canJump;
    public float dashTimer;
    public int keys;
    public int keysReq;
    private Animator _animator;
    private AudioManager _audioManager;

    private bool frd, back, left, right;

    //Methods ----
    private void Start()
    {
        health = 1000;
        currHealth = health;
        scoreText.text = "Score : " + _score;
        healthText.text = "Health : " + currHealth + "/" + health;
        canJump = false;
        keys =  0;
        dashTimer = Time.deltaTime;
        mThrust = 0.08f;
        _animator = gameObject.GetComponent<Animator>();
        _audioManager = AudioManager.Instance;
        frd = back = left = right = false;
        
    }

    private void FixedUpdate()
    {
        Movement();
        if (currHealth <= 0 ) //Death
        {
            _audioManager.sounds[3].source.Pause();
            _audioManager.Play("EndTheme");
            StartCoroutine(PlayerDeath());
        }

        if (gameObject.transform.position.y < -10)
        {
            gameObject.transform.position = new Vector3(0, 1.5f, 0);
            currHealth -= 300;
            healthText.text = "Health : " + currHealth + "/" + health;
        }
    }

    public void AddPoint(int point)
    {
        _score += point;
        scoreText.text = "Score : " + _score;
    }
    public int GetPoint()
    {
        return _score;
    }
    
    public void OnShoot()
    {
        gameObject.GetComponentInChildren<WeaponBehaviour>().OnShoot();
    }

    public void OnForward(InputAction.CallbackContext ctx)
    {
        frd = ctx.ReadValueAsButton();
    }

    public void OnBackwards(InputAction.CallbackContext ctx)
    {
        back = ctx.ReadValueAsButton();
    }
    
    public void OnLeft(InputAction.CallbackContext ctx)
    {
        left = ctx.ReadValueAsButton();
    }
    
    public void OnRight(InputAction.CallbackContext ctx)
    {
        right = ctx.ReadValueAsButton();
    }
    
    public void OnJump()
    {
        if (canJump)
        {
            _audioManager.Play("Jump");
            _animator.SetBool("Jumping", true);
            GetComponentInParent<Rigidbody>().AddForce(transform.up * 150);
        }
    }
    
    public void OnDash()
    {
        if (canJump)
        {
            if (Time.realtimeSinceStartup >= dashTimer + 4f) {
                _audioManager.Play("Dash");
                _animator.SetBool("Dashing", true);
                dashTimer = Time.realtimeSinceStartup;
                GetComponentInParent<Rigidbody>().velocity = transform.forward * 50;
            }
        }
    }
    private void Movement()
    {
            if (frd)
            {
                transform.Translate(Vector3.forward * mThrust);
            } 
            if (back)
            {
                transform.Translate(Vector3.back * mThrust);
            }
        
            
            if (left)
            {
                transform.Rotate(Vector3.up, -7);
            }
            if (right)
            {
                transform.Rotate(Vector3.up, 7);
            }
    }
    
    public void ButtonSpawnEnemy(){

        GameObject enemy = Instantiate(enemyPf);
        //enemy.transform.eulerAngles = new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y + 130, transform.eulerAngles.z);
        enemy.transform.position = new Vector3(0, 0.51f, 10);
    }

    public void AddHp(int hp)
    {
        currHealth += hp;
        healthText.text = "Health : " + currHealth + "/" + health;
    }

    public void Hit(int hp)
    {
        currHealth -= hp;
        healthText.text = "Health : " + currHealth + "/" + health;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraFollow>().start = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            _audioManager.Play("FireballHit");
            Hit(collision.collider.gameObject.GetComponent<Fireball>().dmg);
        }

    }
    
    private void EndAnimation(string n){
        _animator.SetBool(n, false);
    }
    
    IEnumerator PlayerDeath()
    {
        _animator.SetBool("Deadent", true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
