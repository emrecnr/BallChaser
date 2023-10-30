using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    public void PlayEffect()
    {
        _gameManager.BoxEffect(transform.position);
        gameObject.SetActive(false);
    }
}
