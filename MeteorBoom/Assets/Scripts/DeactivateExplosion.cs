using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateExplosion : MonoBehaviour {

    private void OnEnable()
    {
        Invoke("Deactivate", 1f);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
