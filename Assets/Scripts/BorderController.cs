using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        BlocksGameController.gameOver = true;
        Destroy(other);
        Debug.Log("Game over.");
    }
}
