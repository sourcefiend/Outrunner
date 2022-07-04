using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float pointOfReach;

    private float attackTime;

    public float attackSpeed;

    private void Update()
    {
        if (player != null) {
            if (Vector2.Distance(transform.position, player.position) > pointOfReach) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else {
                if (Time.time >= attackTime) {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenMeleeAttack;
                }
            }
        }
    }

    IEnumerator Attack() {
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;

        while (percent <= 1) {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
}
