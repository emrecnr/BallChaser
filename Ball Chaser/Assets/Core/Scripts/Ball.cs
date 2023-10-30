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

    bool _first;

    private void Start()
    {
        _ballNumberText.text = number.ToString();   
    }

    private void State()
    {
        _first = true;
    }
    public void ChangeState()
    {
        Invoke("State", 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(number.ToString()) && _first)
        {
            _ballParticle.Play();
            collision.gameObject.SetActive(false);
            number += number;
            gameObject.tag = number.ToString();
            _ballNumberText.text = number.ToString();
            switch (number)
            {

                case 4:
                    _spriteRenderer.sprite = _gameManager._sprites[1];
                    break;
                case 8:
                    _spriteRenderer.sprite = _gameManager._sprites[2];
                    break;
                case 16:
                    _spriteRenderer.sprite = _gameManager._sprites[3];
                    break;
                case 32:
                    _spriteRenderer.sprite = _gameManager._sprites[4];
                    break;
                case 64:
                    _spriteRenderer.sprite = _gameManager._sprites[5];
                    break;
                case 128:
                    _spriteRenderer.sprite = _gameManager._sprites[6];
                    break;
                case 256:
                    _spriteRenderer.sprite = _gameManager._sprites[7];
                    break;
                case 512:
                case 1024:
                case 2048:
                    _spriteRenderer.sprite = _gameManager._sprites[8];
                    break;                  
                    
            }
            _first = false;
            Invoke("State", 2f);
        }
    }
}
