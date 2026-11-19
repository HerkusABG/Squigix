using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : InitComponent
{
    public void UniqueInitialize()
    {
        ObjectList.exitPortal = this;
    }

    public void ExecuteExit()
    {
        SceneTracker.EndOfDemo();
    }
}
