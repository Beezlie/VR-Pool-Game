using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardBallBST
{
    //TODO - for now hardcode but after use scale to find true radius
    //https://answers.unity.com/questions/35753/how-do-i-find-the-size-of-a-gameobject.html
    //Right now the radius is wrong because the ball game objects have been scaled
    private const float BallDistance = 0.15f;
    private const int MaxDepth = 4;

    public BallNode rootNode { get; }

    public BilliardBallBST(List<GameObject> balls, Vector3 initialPosition)
    {
        rootNode = BuildTree(balls, 0, 0, initialPosition, 0);
    }

    //TODO - swap 8 ball with another ball to maintain its position
    private BallNode BuildTree(List<GameObject> balls, int i, int depth, Vector3 position, int nodeId)
    {
        if (i >= balls.Count || depth > MaxDepth)
        {
            return null;
        }

        GameObject ball = balls[i];
        ball.transform.position = position;
        BallNode next = new BallNode(ball);
        Debug.Log("Initialized ball " + ball.name + " at " + position + " with id " + nodeId);

        next.Left = BuildTree(balls, i + depth + 1, depth + 1, new Vector3(position.x + BallDistance, position.y, position.z + BallDistance), nodeId + 10);
        next.Right = BuildTree(balls, i + depth + 2, depth + 1, new Vector3(position.x + BallDistance, position.y, position.z - BallDistance), nodeId + 11);
        return next;
    }
}
