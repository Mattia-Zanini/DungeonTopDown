using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float attackSpeed = 1f;
    private float canattack;
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canattack)
            {
                other.gameObject.GetComponent<Health>().UpdateHealth(-damage);
                canattack = 0f;
            }
            else
                canattack += Time.deltaTime;
        }
    }
}
