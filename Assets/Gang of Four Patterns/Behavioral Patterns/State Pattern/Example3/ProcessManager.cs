namespace StatePatternExample3
{
    public class ProcessManager : IProcessManager
    {
        private Process _process;

        public ProcessManager(Process process)
        {
            _process = process;
            _process.OnEnter(this);
        }

        public void ChangeProcess(Process process)
        {
            if (_process != null)
                _process.OnExit(this);
            _process = process;
            _process.OnEnter(this);
        }

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            _process.OnUpdate(this, elapseSeconds, realElapseSeconds);
        }
    }
}
