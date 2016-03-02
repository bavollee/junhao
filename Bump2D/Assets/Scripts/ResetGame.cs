using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetGame : MonoBehaviour
{
    private GameObject[] _players;
    private Dictionary<GameObject, Vector3> _playerPosDict;


    void Awake()
    {
        _players = GameObject.FindGameObjectsWithTag("Player");

        _playerPosDict = new Dictionary<GameObject, Vector3>();
        foreach (GameObject player in _players)
        {
            _playerPosDict.Add(player, player.transform.position);
        }
    }

    void Start()
    {
        EventTriggerListener.Get(gameObject).onClick += OnClick;
    }

    void OnClick(GameObject go)
    {
        foreach (KeyValuePair<GameObject, Vector3> kv in _playerPosDict)
        {
            GameObject player = kv.Key;

            Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();
            if (null != rb2d)
                rb2d.Sleep();

            player.transform.position = kv.Value;
            player.SetActive(true);
        }

        Time.timeScale = 1;

        Debug.Log("Reset game.");
    }
}
