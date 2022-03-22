using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    //--Game objects / logic----
    int _count;
    public TextMeshProUGUI tutorialText;

    //--Methods----
    void Start()
    {
        _count = 0;
    }

    void Update()
    {
        if (_count < 1 && GameObject.FindGameObjectWithTag("Player").transform.position.z > 1)
        {
            _count++;
            tutorialText.text = "Be careful not to fall!";
        }
        if (_count < 2 && GameObject.FindGameObjectWithTag("Player").transform.position.z > 5)
        {
            _count++;
            tutorialText.text = "Collectable packs for hp and ammo!";
        }
        if (_count < 3 && GameObject.FindGameObjectWithTag("Player").transform.position.z > 8)
        {
            _count++;
            tutorialText.text = "Keys are needed to proceed to the next level!";
        }
        if (_count < 4 && GameObject.FindGameObjectWithTag("Player").transform.position.z > 12)
        {
            _count++;
            tutorialText.text = "A melee enemy is coming for you. Shoot with left mouse button!";
        }
        if (_count < 5 && GameObject.FindGameObjectWithTag("Player").transform.position.z > 16)
        {
            _count++;
            tutorialText.text = "You can also jump with space and dash with left shift!";
        }
    }
}
