using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Updater
    {
        private readonly List<Action> _actions = new();

        public void Update()
        {
            foreach(var action in _actions)
                action?.Invoke();
        }

        public void OnUpdate(Action action)
        {
            _actions.Add(action);
        }
    }
}