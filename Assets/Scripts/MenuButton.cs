using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject _button;

    public void PlayAgain()
    {
        _button.SetActive(false);
        PlayerController.Instance.ResetPlayer();
        SceneManager.LoadScene(0);
    }
}
