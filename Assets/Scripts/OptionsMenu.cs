using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
    {
        private InputActionMap _actionMap;
        // private TextMeshProUGUI forward;
        // private TextMeshProUGUI backwards;
        // private TextMeshProUGUI left;
        // private TextMeshProUGUI right;
        private TextMeshProUGUI jump;
        private TextMeshProUGUI dash;
        private TextMeshProUGUI shoot;
        void Start()
        {
            _actionMap = GetComponent<PlayerInput>().currentActionMap;
            _actionMap.LoadBindingOverridesFromJson(PlayerPrefs.GetString("bindings"));
            
            gameObject.GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("volume");
            
            // forward = GameObject.Find("Forward").GetComponentInChildren<TextMeshProUGUI>();
            // backwards = GameObject.Find("Back").GetComponentInChildren<TextMeshProUGUI>();
            // left = GameObject.Find("Left").GetComponentInChildren<TextMeshProUGUI>();
            // right = GameObject.Find("Right").GetComponentInChildren<TextMeshProUGUI>();
            jump = GameObject.Find("Jump").GetComponentInChildren<TextMeshProUGUI>();
            dash = GameObject.Find("Dash").GetComponentInChildren<TextMeshProUGUI>();
            shoot = GameObject.Find("Shoot").GetComponentInChildren<TextMeshProUGUI>();

            // forward.text = _actionMap["Forward"].GetBindingDisplayString();
            // backwards.text = _actionMap["Backwards"].GetBindingDisplayString();
            // left.text = _actionMap["Left"].GetBindingDisplayString();
            // right.text = _actionMap["Right"].GetBindingDisplayString();
            jump.text = _actionMap["Jump"].GetBindingDisplayString();
            dash.text = _actionMap["Dash"].GetBindingDisplayString();
            shoot.text = _actionMap["Shoot"].GetBindingDisplayString();
            
            // GameObject.Find("Forward").GetComponent<Keybind>().SetAction(_actionMap["Forward"]);
            // GameObject.Find("Back").GetComponent<Keybind>().SetAction(_actionMap["Backwards"]);
            // GameObject.Find("Left").GetComponent<Keybind>().SetAction(_actionMap["Left"]);
            // GameObject.Find("Right").GetComponent<Keybind>().SetAction(_actionMap["Right"]);
            GameObject.Find("Dash").GetComponent<Keybind>().SetAction(_actionMap["Dash"]);
            GameObject.Find("Jump").GetComponent<Keybind>().SetAction(_actionMap["Jump"]);
            GameObject.Find("Shoot").GetComponent<Keybind>().SetAction(_actionMap["Shoot"]);
            
            // GameObject.Find("Forward").GetComponent<Keybind>().SetText(forward);
            // GameObject.Find("Back").GetComponent<Keybind>().SetText(backwards);
            // GameObject.Find("Left").GetComponent<Keybind>().SetText(left);
            // GameObject.Find("Right").GetComponent<Keybind>().SetText(right);
            GameObject.Find("Dash").GetComponent<Keybind>().SetText(dash);
            GameObject.Find("Jump").GetComponent<Keybind>().SetText(jump);
            GameObject.Find("Shoot").GetComponent<Keybind>().SetText(shoot);
            
        }

        public void SaveBinds()
        {
            var savedBindings = _actionMap.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString("bindings",savedBindings);

            var savedVolume = AudioManager.Instance.master;
            PlayerPrefs.SetFloat("volume",savedVolume);
        }

        public void changeVolume(float value)
        {
            AudioManager.Instance.master = value;
            AudioManager.Instance.changeVolume();
        }
    }

