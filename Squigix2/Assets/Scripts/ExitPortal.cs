using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    private void Start()
    {
        ObjectList.exitPortal = this;
        Debug.Log("Assigning new");
    }

    public void ExecuteExit()
    {
        SceneTracker.EndOfDemo();
    }
}
