using System;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Timer
    {
        private readonly float _startTime;
        private readonly float _endTime;
        private float _timer;
        
        public event Action OnEnd;

        public Timer(float startTime, float endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
            _timer = GetRandomTime();
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
            _timer = GetRandomTime();
        }

        private float GetRandomTime()
        {
            return Random.Range(_startTime, _endTime);
        }
    }
}