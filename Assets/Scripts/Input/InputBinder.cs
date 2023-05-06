using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InputBinder : MonoBehaviour
    {
        private Input _input;

        private void Awake()
        {
            _input = new Input();
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Enable();
        }

        public void BindLMBCLick(Action action)
        {
            _input.Player.Attack.performed += _ => action.Invoke();
        }

        public void BindRMBCLick(Action action)
        {
            _input.Player.Ultimate.performed += _ => action.Invoke();
        }
    }
}