using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Game objects / logic ----
    private GameObject _toFollow;
    public float duration = 1f;
    public AnimationCurve curve;
    public Vector3 offset;
    public Vector3 shake = new Vector3(4,4,4);
    public bool start;
    //private Camera _cam;

    //Methods ----
    void Start()
    {
        transform.eulerAngles = new Vector3((float)33.5, 0,0);
        offset = new Vector3(0, 10, -15);
        _toFollow = GameObject.FindGameObjectWithTag("Player");
        start = false;
        //_cam = GetComponent<Camera>();
    }

    void Update()
    {
        transform.LookAt(_toFollow.transform);
        if (start) { start = false; StartCoroutine(Shake()); }
        transform.position = Vector3.MoveTowards(transform.position, (_toFollow.transform.position + offset), 2f);
    }

    private IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0.8f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + new Vector3(strength, strength, strength)   + Random.insideUnitSphere ;
            yield return null;
        }
        transform.position = startPosition;
    }
}
