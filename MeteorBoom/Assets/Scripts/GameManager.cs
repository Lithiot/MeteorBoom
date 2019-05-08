using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private int cityHealth = 3;
    [SerializeField] private int playerMoney = 0;
    public static GameManager instance = null;
    public Gun[] guns;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void CityDamaged()
    {
        cityHealth -= 1;
    }

    public void AddMoney()
    {
        playerMoney += 1;
    }
}
