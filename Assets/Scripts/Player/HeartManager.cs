using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public CharacterController characterController;
    public Sprite[] hearts;
    public Image image;

    void Start()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    void Update()
    {
        image.sprite = hearts[characterController.hearts];
    }
}

