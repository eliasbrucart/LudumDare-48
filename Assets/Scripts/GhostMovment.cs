using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovment : MonoBehaviour
{
    public float speed = 20;
    public enum Direction
    { Left, LeftUp, Up, RightUp, Right, RightDown, Down, LeftDown }

    public float timeToMove = 2;
    public float timeToNewDir = 1;
    int direction;
    public float actualRandom;
    public GameObject Player;

    int countToMoveTowardsPlayer = 0;
    void Start()
    {
        actualRandom = getRandomDirection();
    }

    void Update()
    {
        if (Player.transform.position.x + 8 < this.transform.position.x ||
            Player.transform.position.x - 8 > this.transform.position.x ||
            Player.transform.position.y - 8 > this.transform.position.y ||
            Player.transform.position.y + 8 < this.transform.position.y)
        { }
        else
        {
            timeToNewDir -= Time.deltaTime;
            Vector3 newpos;
            if (timeToNewDir <= 0)
            {
                countToMoveTowardsPlayer++;
                actualRandom = getRandomDirection();
                if (countToMoveTowardsPlayer == 2)
                {
                    countToMoveTowardsPlayer = 0;
                    if (Player.transform.position.x > this.transform.position.x && Player.transform.position.y > this.transform.position.y)
                    {
                        direction = 3;
                        timeToNewDir = timeToMove;
                    }
                    if (Player.transform.position.x < this.transform.position.x && Player.transform.position.y > this.transform.position.y)
                    {
                        direction = 1;
                        timeToNewDir = timeToMove;
                    }
                    if (Player.transform.position.x < this.transform.position.x && Player.transform.position.y < this.transform.position.y)
                    {
                        direction = 7;
                        timeToNewDir = timeToMove;
                    }
                    if (Player.transform.position.x > this.transform.position.x && Player.transform.position.y < this.transform.position.y)
                    {
                        direction = 5;
                        timeToNewDir = timeToMove;
                    }
                }
                else
                {
                    switch (actualRandom)
                    {
                        case 0:
                            direction = 0;
                            timeToNewDir = timeToMove;
                            break;
                        case 1:
                            direction = 1;
                            timeToNewDir = timeToMove;
                            break;
                        case 2:
                            direction = 2;
                            timeToNewDir = timeToMove;
                            break;
                        case 3:
                            direction = 3;
                            timeToNewDir = timeToMove;
                            break;
                        case 4:
                            direction = 4;
                            timeToNewDir = timeToMove;
                            break;
                        case 5:
                            direction = 5;
                            timeToNewDir = timeToMove;
                            break;
                        case 6:
                            direction = 6;
                            timeToNewDir = timeToMove;
                            break;
                        case 7:
                            direction = 7;
                            timeToNewDir = timeToMove;
                            break;

                        default:
                            break;
                    }
                }
            }
            switch (direction)
            {
                case 0:
                    this.transform.Translate(Vector3.left * Time.deltaTime * speed);

                    break;
                case 1:
                    newpos = Vector3.left + Vector3.up;
                    this.transform.Translate(newpos * Time.deltaTime * speed);
                    break;
                case 2:
                    this.transform.Translate(Vector3.up * Time.deltaTime * speed);
                    break;
                case 3:
                    newpos = Vector3.right + Vector3.up;
                    this.transform.Translate(newpos * Time.deltaTime * speed);
                    break;
                case 4:
                    this.transform.Translate(Vector3.right * Time.deltaTime * speed);
                    break;
                case 5:
                    newpos = Vector3.right + Vector3.down;
                    this.transform.Translate(newpos * Time.deltaTime * speed);
                    break;
                case 6:
                    this.transform.Translate(Vector3.down * Time.deltaTime * speed);
                    break;
                case 7:
                    newpos = Vector3.left + Vector3.down;
                    this.transform.Translate(newpos * Time.deltaTime * speed);
                    break;

                default:
                    break;
            }
        }
    }

    private int getRandomDirection()
    {
        int direction;
        direction = Random.Range(0, 7);
        return direction;
    }
}
