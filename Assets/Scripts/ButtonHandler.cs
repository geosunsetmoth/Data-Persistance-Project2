using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    //Load Scenes
    public void GoToScene(int n)
    {
        SceneManager.LoadScene(n);
    }
}
