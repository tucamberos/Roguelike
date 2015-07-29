﻿using UnityEngine;
using System.Collections;

public class Enemy : MovingObject {

    public bool isEnemyStrong;

    private bool skipCurrentMove;
    private Transform player;


    protected override void Start() { 
    
        GameController.Instance.AddEnemyToList(this);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        skipCurrentMove = true;
        base.Start();
    }

    public void MoveEnemy()
    {

        if(skipCurrentMove) 
        {
            if(isEnemyStrong)
            {
                int chanceToMove = Random.Range(1, 4);
                if(chanceToMove > 1)
                {
                    skipCurrentMove = false;
                    return;
                }
            }
            else
            {
                skipCurrentMove = false;
                return;
            }
        }
        int xAxis = 0;
        int yAxis = 0;

        float xAxisDistance = Mathf.Abs(player.position.x - transform.position.x);
        float yAxisDistance = Mathf.Abs(player.position.y - transform.position.y);

        if (xAxisDistance > yAxisDistance)
        {
            if (player.position.x > transform.position.x)
            {
                xAxis = 1;
            }
            else
            {
                xAxis = -1;

            }
        }

        else
        {
            if(player.position.y > transform.position.y)
            {
                yAxis = -1;
                    
            }
            else
            {
                yAxis = -1;
            
            }

        }

        Move(xAxis, yAxis);
        skipCurrentMove = true;
    }
}

              

