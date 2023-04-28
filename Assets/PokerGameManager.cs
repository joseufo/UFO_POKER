using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerGameManager : MonoBehaviour
{
    public static PokerGameManager instance;
    PokerRoomManager roomManager;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        roomManager = GetComponent<PokerRoomManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
