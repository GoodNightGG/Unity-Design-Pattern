namespace StatePatternExample3
{
    public abstract class Process
    {
        public abstract void OnEnter(IProcessManager processManager);
        public abstract void OnUpdate(IProcessManager processManager, float elapseSeconds, float realElapseSeconds);
        public abstract void OnExit(IProcessManager processManager);
    }
}
