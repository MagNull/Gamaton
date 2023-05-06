using System;

namespace DefaultNamespace
{
    public class Timer
    {
        private float _startTime;
        private float _timer;
        
        public event Action OnEnd;

        public Timer(float time)
        {
            _timer = time;
            _startTime = time;
        }
        
        public void Tick(float deltaTime)
        {
            if (_timer <= 0)
                return;
            _timer -= deltaTime;
            if (_timer <= 0f)
                Reset();
        }

        private void Reset()
        {
            OnEnd?.Invoke();
            _timer = _startTime;
        }
    }
}