using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public string loadScene;
    public string winScene;

    [SerializeField] Transform _lastPosition;
    [SerializeField] LevelLoader _levelLoader;
    private CameraMovement _cameraMovement;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (other.CompareTag("Player"))
        {
            // SceneManager.LoadScene(loadScene);
            // record the last position the player was at the scene
            GameManager.Instance.SetSceneLastPosition(buildIndex, _lastPosition.position);
            
            if (_cameraMovement != null)
            {
                GameManager.Instance.SetSceneLastCameraMinPosition(buildIndex, _cameraMovement.minPosition);
                GameManager.Instance.SetSceneLastCameraMaxPosition(buildIndex, _cameraMovement.maxPosition);
            }

            _levelLoader.LoadNextLevel(loadScene);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);

    }

}
