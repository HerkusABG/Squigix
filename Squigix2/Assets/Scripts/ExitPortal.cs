using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : InitComponent
{
    [SerializeField]
    LevelEnd levelEnd;
    public void UniqueInitialize()
    {
        ObjectList.exitPortal = this;
    }

    public void ExecuteExit()
    {
        levelEnd.LoadLevelEnd();
        //SceneTracker.EndOfDemo();
    }

    
}
