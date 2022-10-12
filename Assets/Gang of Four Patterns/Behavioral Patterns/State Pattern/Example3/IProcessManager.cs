using StatePatternExample1;

namespace StatePatternExample3
{
    public interface IProcessManager
    {
        void ChangeProcess(Process process);
        void Update(float elapseSeconds, float realElapseSeconds);
    }
}
