using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBall : BallEvent
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PoolBall _poolBall;
   
     public  override void Activate(Collider2D otner) // –еализаци€ абстрактного метода.
    {
        CreateNewBall(otner);
        _playerController.AddBall();
        gameObject.SetActive(false);
    }

    private void CreateNewBall(Collider2D otner) // ƒобавл€ю м€ч он по€вл€етс€ р€дом с м€чом у которого произошла колизи€, придаю ускорение и вектор движени€ как у первого м€ча.
    {
        foreach (GameObject obj in _poolBall.PoolBalls)
        {
            if (!obj.activeInHierarchy)
            {
                Vector2 vectorMove = otner.transform.position;
                obj.transform.position = new Vector2(vectorMove.x, otner.transform.position.y - 1);
                obj.SetActive(true);
                foreach (var item in _poolBall.PoolVector)
                {
                    item.ball_direction = otner.GetComponent<BallVector>().ball_direction;
                }
                foreach (var item in _poolBall.PoolRigidBody)
                {
                    item.velocity = otner.GetComponent<Rigidbody2D>().velocity;
                }
                break;
            }
        }
    }
}
