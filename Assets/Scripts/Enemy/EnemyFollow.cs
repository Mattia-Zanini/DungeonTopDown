using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private SpriteRenderer r;
    [SerializeField] private float movementSpeed = 4f;
    [SerializeField] private Transform target;
    private Vector2 previousPosition;
    private void Awake()
    {
        r = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement() => transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    private void UpdateRenderDirection()
    {

    }
}
