using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI _dynamiteNumberText;
    [SerializeField] private int number;
    private List<Collider2D> colliders = new List<Collider2D>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(number.ToString())) Force();
        
    }
   
    private void Force()
    {
        var contactFilter2D = new ContactFilter2D
        {
            useTriggers = true
        };
        Physics2D.OverlapBox(transform.position,transform.localScale* 2,20f,contactFilter2D, colliders);

        _gameManager.BoomEffect(transform.position);
        gameObject.SetActive(false);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Box")) 
                collider.gameObject.GetComponent<Box>().PlayEffect();

            else 
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce(90 * new Vector2(0, 6), ForceMode2D.Force);

        }
    }
}
