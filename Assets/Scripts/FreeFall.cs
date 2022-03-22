using UnityEngine;

public class FreeFall : MonoBehaviour
{
    //Game objects ----
    public GameObject objPf;
    private float _waitTime = 1.0f;
    private float _timer;

    //Methods ----
    void Start()
    {
        _timer = 0.0f;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _waitTime)
        {
            _timer = _timer - _waitTime;
            Spawn();
        }
    }

    void Spawn()
    {
        float zTop = GameObject.Find("/Borders/ZTop").transform.position.z;
        float zBot = GameObject.Find("/Borders/ZBot").transform.position.z;
        float xTop = GameObject.Find("/Borders/XTop").transform.position.x;
        float xBot = GameObject.Find("/Borders/XBot").transform.position.x;
        var position = new Vector3(Random.Range(xBot + 1, xTop - 1), 10, Random.Range(zBot + 1, zTop - 1));
       // var rotation = new Vector3(ObjPf.transform.rotation.x + Random.Range(0, 180), ObjPf.transform.rotation.y, ObjPf.transform.rotation.z);
        Instantiate(objPf, position, objPf.transform.rotation);
    }
}
