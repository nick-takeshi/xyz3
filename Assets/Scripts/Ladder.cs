using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _hero;

    private void Start()
    {
        _hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_hero.velocity.y > 0.5)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _speed);
            }
            else if (_hero.velocity.y < 0.5)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_speed);

            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}
