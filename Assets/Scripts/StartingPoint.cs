using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingPoint : MonoBehaviour
{
    private PlayerController _player;
    private GameManager _gameManager;
    private CameraMovement _camera;

    private void Start()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        // find player
        _player = PlayerController.Instance;
        _gameManager = GameManager.Instance;

        Vector3 _pos = _gameManager.GetSceneLastPosition(buildIndex);
        Vector2 _min = _gameManager.GetSceneLastCameraMinPosition(buildIndex);
        Vector2 _max = _gameManager.GetSceneLastCameraMaxPosition(buildIndex);

        if (_pos == Vector3.zero)
        {
            
        }
        else
        {
            this.transform.position = _pos;
        }
        _player.transform.position = this.transform.position;

        _camera = Camera.main.GetComponent<CameraMovement>();

        if (_min != Vector2.zero)
        {
            _camera.minPosition = _min;
        }

        if (_max != Vector2.zero)
        {
            _camera.maxPosition = _max;
        }
    }
}
