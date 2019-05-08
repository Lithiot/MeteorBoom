using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

    [SerializeField] PlayerControls player;
    [SerializeField] Image gunSprite;

    private void Start()
    {
        gunSprite.sprite = player.GetGun().sprite;
    }

}
