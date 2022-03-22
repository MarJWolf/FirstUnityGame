using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    //Game objects / logic ----
    public int  currentSceneNum;
    private GameObject _cubeP;
    
    //Methods ----
    void Start()
    {
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;
        _cubeP = GameObject.FindGameObjectWithTag("Player");
        switch (currentSceneNum)
        {
            case 1:
                _cubeP.GetComponent<Player>().keyText.text = "Keys : 0/" + (_cubeP.GetComponent<Player>().keysReq = 1);
                break;
            case 2:
                _cubeP.GetComponent<Player>().keyText.text = "Keys : 0/" + (_cubeP.GetComponent<Player>().keysReq = 2);
                break;
            case 3:
                _cubeP.GetComponent<Player>().keyText.text = "Keys : 0/" + (_cubeP.GetComponent<Player>().keysReq = 4);
                break;
            default:
                _cubeP.GetComponent<Player>().keyText.text = "Keys : 0/" + (_cubeP.GetComponent<Player>().keysReq = 0);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Player") && _cubeP.GetComponent<Player>().keys >= _cubeP.GetComponent<Player>().keysReq && _cubeP.GetComponent<Player>().GetPoint()  >= 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }  
    }

}
