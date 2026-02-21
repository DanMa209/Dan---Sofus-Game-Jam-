using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
