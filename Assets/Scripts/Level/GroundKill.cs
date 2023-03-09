using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundKill : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private const string BALL = "Ball";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(BALL))
        {
            collision.gameObject.SetActive(false);
            collision.transform.position = _parent.position;
        }
    }
}
