using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputMgr : MonoBehaviour
{
    public GameObject player;
    public KeyCode keyCode = KeyCode.None;
    public bool keyboardMode = true;

    private AutoRot _autoRotCom;
    private RunForward _runForwardCom;
    private bool _bRun = false;


    void Awake()
    {
#if UNITY_ANDROID
        keyboardMode = false;
#endif
    }

    void Start()
    {
        _autoRotCom = player.GetComponent<AutoRot>();
        _runForwardCom = player.GetComponent<RunForward>();

        EventTriggerListener.Get(gameObject).onDown += OnClickDown;
        EventTriggerListener.Get(gameObject).onUp += OnClickUp;
    }

    void Update()
    {
        if (keyboardMode)
        {
            if (KeyCode.None != keyCode)
            {
                _bRun = Input.GetKey(keyCode);
            }
        }

        if (_bRun)
        {
            _runForwardCom.Run();
        }
    }

    void OnClickDown(GameObject go)
    {
        _bRun = true;
        _autoRotCom.enabled = false;
    }

    void OnClickUp(GameObject go)
    {
        _bRun = false;

        _autoRotCom.ReverseRot();
        _autoRotCom.enabled = true;
    }
}
