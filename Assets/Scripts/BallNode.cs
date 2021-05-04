using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallNode
{   
    public BallNode(GameObject ball)
    {
        Ball = ball;
    }

    public GameObject Ball { get; }
    public BallNode Left { get; set; }
    public BallNode Right { get; set; }
}
