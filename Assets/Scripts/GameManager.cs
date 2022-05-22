using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{

    private Dictionary<int, Vector3> _scenePositions = new Dictionary<int, Vector3>();
    private Dictionary<int, Vector2> _lastCameraMinPosition = new Dictionary<int, Vector2>();
    private Dictionary<int, Vector2> _lastCameraMaxPosition = new Dictionary<int, Vector2>();

    [SerializeField] GameObject _uIHeart;
    [SerializeField] GameObject _uIInventory;
    [SerializeField] GameObject _uIResetButton;
    [SerializeField] GameObject _uiPlayAgain;
    //[SerializeField] GameObject _uiWalletSubmit;

    public List<WorldObject> _worldObjects;
    
    //tracking win conditions
    public bool _hasCollectedOre;
    public bool _hasCollectedLeather;
    public bool _hasCollectedCrystal;
    public bool _lit;


    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        SessionData.Instance.SetStartTime();
        SessionData.Instance.UpdateDebugUI();
    }

    public void SetSceneLastPosition(int _sceneId, Vector3 _pos)
    {
        Vector3 temp;
        if (_scenePositions.TryGetValue(_sceneId, out temp))
        {
            _scenePositions[_sceneId] = _pos;
        }
        else
        {
            _scenePositions.Add(_sceneId, _pos);
        }
    }

    public void SetSceneLastCameraMinPosition(int _sceneId, Vector2 _min)
    {
        Vector2 temp;
        if (_lastCameraMinPosition.TryGetValue(_sceneId, out temp))
        {
            _lastCameraMinPosition[_sceneId] = _min;
        }
        else
        {
            _lastCameraMinPosition.Add(_sceneId, _min);
        }
    }

    public void SetSceneLastCameraMaxPosition(int _sceneId, Vector2 _max)
    {
        Vector2 temp;
        if (_lastCameraMaxPosition.TryGetValue(_sceneId, out temp))
        {
            _lastCameraMaxPosition[_sceneId] = _max;
        }
        else
        {
            _lastCameraMaxPosition.Add(_sceneId, _max);
        }
    }

    public Vector3 GetSceneLastPosition(int _sceneId)
    {
        Vector3 temp;

        //Debug.Log("Scene passed: " + _sceneId);

        if(_scenePositions.TryGetValue(_sceneId, out temp))
        {
            return _scenePositions[_sceneId];
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector2 GetSceneLastCameraMinPosition(int _sceneId)
    {
        Vector2 temp;

        if (_lastCameraMinPosition.TryGetValue(_sceneId, out temp))
        {
            return _lastCameraMinPosition[_sceneId];
        }
        else
        {
            return Vector2.zero;
        }
    }

    public Vector2 GetSceneLastCameraMaxPosition(int _sceneId)
    {
        Vector2 temp;

        if (_lastCameraMaxPosition.TryGetValue(_sceneId, out temp))
        {
            return _lastCameraMaxPosition[_sceneId];
        }
        else
        {
            return Vector2.zero;
        }
    }

    public void Restart()
    {
        _scenePositions.Clear();
        _lastCameraMinPosition.Clear();
        _lastCameraMaxPosition.Clear();
        PlayerController.Instance.gameObject.GetComponent<HeartSystem>().Reset();

        Inventory _inventory;
        _inventory = PlayerController.Instance.GetComponent<Inventory>();

        for (int i = 0; i < _inventory.slots.Length; i++)
        {
            if (_inventory.isFull[i])
            {
                _inventory.isFull[i] = false;
                GameObject.Destroy(_inventory.slots[i].transform.GetChild(0).gameObject);
            }
        }
        _hasCollectedCrystal = false;
        _hasCollectedLeather = false;
        _hasCollectedOre = false;
        _lit = false;

        WorldItemManager.Instance.Reset();

        SessionData.Instance.ResetScore();
    }

    public void WinGame()
    {
        Restart();
        _uiPlayAgain.SetActive(true);
        //_uiWalletSubmit.SetActive(true);
        
    }

    public void ItemTaken (GameObject obj)
    {
        foreach(var item in _worldObjects)
        {
            if (item.gameObject == obj)
            {
                item._taken = true;
                item.gameObject.SetActive(false);
            }
        }
    }

    public void ResetButton()
    {
        Restart();
        SceneManager.LoadScene(1);
    }

    public void DisableUI()
    {
        _uIHeart.SetActive(false);
        _uIInventory.SetActive(false);
        _uIResetButton.SetActive(false);
    }

    public void EnableUI()
    {
        _uIHeart.SetActive(true);
        _uIInventory.SetActive(true);
        _uIResetButton.SetActive(true);
    }
}
