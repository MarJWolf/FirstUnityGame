using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


    public class Keybind : MonoBehaviour
    {
        private TextMeshProUGUI _buttonText;
        private InputAction _action;


        public void SetButtonText(string buttonName)
        {
            _buttonText.text = buttonName;
        }


        public void UpdateKeyInput()
        {
            _action.Disable();
            var rebindOperation = _action
                .PerformInteractiveRebinding()
                .WithCancelingThrough("<Keyboard>/escape")
                .WithTargetBinding(0)       //Hardcoded to choose the first index, in reality it should be able to find the index and change it.
                .WithTimeout(60)
                .Start();
            rebindOperation.OnComplete(operation =>
            {
                UpdateGUI();
                rebindOperation.Dispose();
                _action.Enable();
            });
            
            
        }

        public void UpdateGUI()
        {
            SetButtonText(_action.GetBindingDisplayString(0));
        }

        // Update is called once per frame

        public void SetAction(InputAction action)
        {
            _action = action;
        }
        
        public void SetText(TextMeshProUGUI text)
        {
            _buttonText = text;
        }
    }

