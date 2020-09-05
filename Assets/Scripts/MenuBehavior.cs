using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    public Button StartGameBtn;
    public Button QuitGameBtn;
    
    void Start()
    {
        QuitGameBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        StartGameBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }
}
