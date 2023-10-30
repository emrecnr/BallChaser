using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int number;
    [SerializeField] private TextMeshProUGUI _ballNumberText;
    [SerializeField] private ParticleSystem _ballParticle;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _ballNumberText.text = number.ToString();   
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(number.ToString()))
        {
            _ballParticle.Play();
            collision.gameObject.SetActive(false);
            number *= 2;
            gameObject.tag = number.ToString();
            _ballNumberText.text = number.ToString();
        }
    }
}
