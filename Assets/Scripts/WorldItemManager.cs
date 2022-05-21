using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldItemManager : MonoBehaviour
{
    [System.Serializable]
    public struct WorldItem
    {
        public int sceneID;
        public string tag;
        public Vector3 position;
        public bool pickUp;

        
    }

    [SerializeField] List<GameObject> _gameObjects;

    //[SerializeField] WorldItem[] _items;
    [SerializeField] List<WorldItem> _items;

    public static WorldItemManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("Scene " + SceneManager.GetActiveScene().buildIndex);
        LoadItemsInScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadItemsInScene(int sceneID)
    {
        foreach (var item in _items)
        {
            if (item.sceneID == sceneID && !item.pickUp)
            {
                var obj = _gameObjects.Where(ob => ob.CompareTag(item.tag));

                foreach (var i in obj)
                {
                    Instantiate(i, item.position, Quaternion.identity);
                }
            }

        }
    }

    public void ItemPickedUp(GameObject obj)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (obj.CompareTag(_items[i].tag))
            {
                var item = _items[i];
                item.pickUp = true;
                _items[i] = item;
                break;
            }
        }
    }

    public void DropItem(GameObject obj)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (obj.CompareTag(_items[i].tag))
            {
                var item = _items[i];
                item.pickUp = false;
                item.position = obj.transform.position;
                item.sceneID = SceneManager.GetActiveScene().buildIndex;
                _items[i] = item;
                break;
            }
        }
    }

    public void AddNewItem(GameObject obj)
    {
        WorldItem item;
        item.sceneID = SceneManager.GetActiveScene().buildIndex;
        item.tag = obj.tag;
        item.position = obj.transform.position;
        item.pickUp = false;
        _items.Add(item);
    }

    public void Reset()
    {
        _items.Clear();

        WorldItem item1;
        item1.sceneID = 4;
        item1.tag = "Dagger";
        item1.position = new Vector3(-2.15f, -1.66f, 0);
        item1.pickUp = false;
        _items.Add(item1);

        WorldItem item2;
        item2.sceneID = 1;
        item2.tag = "Cow";
        item2.position = new Vector3(18.38f, 3.77f, 0);
        item2.pickUp = false;
        _items.Add(item2);

        WorldItem item3;
        item3.sceneID = 1;
        item3.tag = "Axe";
        item3.position = new Vector3(5.51f, -8.52f, 0);
        item3.pickUp = false;
        _items.Add(item3);

        WorldItem item4;
        item4.sceneID = 1;
        item4.tag = "Tree";
        item4.position = new Vector3(33.69f, -10.52f, 0);
        item4.pickUp = false;
        _items.Add(item4);

        WorldItem item5;
        item5.sceneID = 1;
        item5.tag = "Pickaxe";
        item5.position = new Vector3(24.34f, 15.52f, 0);
        item5.pickUp = false;
        _items.Add(item5);
    }
}
