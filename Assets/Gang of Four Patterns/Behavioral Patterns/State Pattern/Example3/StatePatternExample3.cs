// Unity-Design-Patterns
// Project: https://github.com/GoodNightGG/Unity-Design-Patterns/
// 2022-10-07 Create by:
// GoodNightGG <https://github.com/GoodNightGG>

using System.Threading;
using UnityEngine;

namespace StatePatternExample3
{
    public class StatePatternExample3 : MonoBehaviour
    {

        private ProcessManager processManager;

        void Start()
        {
            processManager = new ProcessManager(new GameLaunch());
        }

        void Update()
        {
            processManager.Update(Time.deltaTime, Time.unscaledDeltaTime);
        }
    }

    public class GameLaunch : Process
    {
        public override void OnEnter(IProcessManager processManager)
        {
            Debug.Log("GameLaunch Setting Something");
        }

        public override void OnExit(IProcessManager processManager)
        {
            Debug.Log("GameLaunch destory some cache");
        }

        public override void OnUpdate(IProcessManager processManager, float elapseSeconds, float realElapseSeconds)
        {
            Debug.Log("Change process after finishing setting");
            processManager.ChangeProcess(new GameLogin());
        }
    }

    public class GameLogin : Process
    {
        public override void OnEnter(IProcessManager processManager)
        {
            Debug.Log("GameLogin Page Ready");
        }

        public override void OnExit(IProcessManager processManager)
        {
            Debug.Log("GameLogin Page Exit");
        }

        public override void OnUpdate(IProcessManager processManager, float elapseSeconds, float realElapseSeconds)
        {
            Debug.Log("GameLogin waiting for login");
            if(Input.GetKeyDown(KeyCode.Return))
                processManager.ChangeProcess(new GameLobby());
        }
    }

    public class GameLobby : Process
    {
        public override void OnEnter(IProcessManager processManager)
        {
            Debug.Log("GameLobby Page OnEnter");
        }

        public override void OnExit(IProcessManager processManager)
        {
            Debug.Log("GameLobby Page OnExit");
        }

        public override void OnUpdate(IProcessManager processManager, float elapseSeconds, float realElapseSeconds)
        {
            Debug.Log("GameLobby Page OnUpdate");
        }
    }
}