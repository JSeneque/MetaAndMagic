using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour
{
    [SerializeField] GameObject _eventManager;

    // Start is called before the first frame update
    void Start()
    {
        TestingEvents testingEvents = _eventManager.GetComponent<TestingEvents>();
        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;
    }

    private void TestingEvents_OnSpacePressed(object sender, System.EventArgs e)
    {
        Debug.Log("Space!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
