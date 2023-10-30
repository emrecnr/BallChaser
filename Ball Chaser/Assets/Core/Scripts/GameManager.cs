using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("--- GENERAL ---")]
    public Sprite[] _sprites;
    [SerializeField] private GameObject[] _balls;
    [SerializeField] private TextMeshProUGUI _ballRemainingText;
    private int _ballRemaining;
    private int _poolIndex;
   
    [Header("--- BALL SYSTEM ---")]
    [SerializeField] private GameObject _shooter;
    [SerializeField] private GameObject _ballSocket;
    [SerializeField] private GameObject _nextBall;
    [SerializeField] private GameObject _selectedBall;

    [Header("--- OTHER SETTINGS ---")]
    [SerializeField] ParticleSystem _boomEffect;
    [SerializeField] ParticleSystem[] _boxEffects;
    private int _boxEffectIndex;


    private void Start()
    {
        _ballRemaining = _balls.Length;
        GetBall(true);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Background"))
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _shooter.transform.position = Vector2.MoveTowards(_shooter.transform.position, new Vector2(mousePosition.x, _shooter.transform.position.y), 30 * Time.deltaTime);

                }
            }
            //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _selectedBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            _selectedBall.transform.parent = null;
            _selectedBall.GetComponent<Ball>().ChangeState();
            GetBall(false);
        }
    }
    private void GetBall(bool firstStep)
    {
        if (firstStep)
        {
            _balls[_poolIndex].transform.SetParent(_shooter.transform);
            _balls[_poolIndex].transform.position = _ballSocket.transform.position;
            _balls[_poolIndex].SetActive(true);
            _selectedBall = _balls[_poolIndex];

            _poolIndex++;
            _balls[_poolIndex].transform.position = _nextBall.transform.position;
            _balls[_poolIndex].SetActive(true);
            _ballRemainingText.text = _ballRemaining.ToString();
            
        }
        else
        {
            if (_balls.Length != 0)
            {
                _balls[_poolIndex].transform.SetParent(_shooter.transform);
                _balls[_poolIndex].transform.position = _ballSocket.transform.position;
                _balls[_poolIndex].SetActive(true);
                _selectedBall = _balls[_poolIndex];

                _ballRemaining--;
                _ballRemainingText.text = _ballRemaining.ToString();

                if (_poolIndex == _balls.Length - 1)
                {
                    Debug.Log("Game Over");
                }
                else
                {
                    _poolIndex++;
                    _balls[_poolIndex].transform.position = _nextBall.transform.position;
                    _balls[_poolIndex].SetActive(true);
                }

            }
        }

    }

    public void BoomEffect(Vector3 effectPosition)
    {
        _boomEffect.gameObject.transform.position = effectPosition;
        _boomEffect.gameObject.SetActive(true);
        _boomEffect.Play();
    }
    public void BoxEffect(Vector3 effectPosition)
    {
        _boxEffects[_boxEffectIndex].gameObject.transform.position = effectPosition;
        _boxEffects[_boxEffectIndex].gameObject.SetActive(true);
        _boomEffect.Play();
        _boxEffectIndex++;
        if (_boxEffectIndex == _boxEffects.Length - 1) _boxEffectIndex = 0;
        else _boxEffectIndex++;


       
    }


    // 2 - Kýrmýzý
    // 4 - SARI
    // 8 - GREEN
    // 16 - BLUE
    // 32 - DARK BLUE
    // 64 - DARK GREEN
    // 128 - PURPLE
    // 256 - ORANGE
    // 512 - C
    // 1024 - SARI
    // 2048 - SARI

}
