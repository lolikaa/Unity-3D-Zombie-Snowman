﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;


    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;

        GetComponentInChildren<Weapon>().enabled = false;
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
