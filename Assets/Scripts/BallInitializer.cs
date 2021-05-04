using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallInitializer : MonoBehaviour
{
	public GameObject cueBall;
	public List<GameObject> billiardBalls = new List<GameObject>();

	// Start is called before the first frame update
	void Start()
    {
		ResetBallPositions();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void ResetBallPositions()
    {
		//Reset cue-ball position
		cueBall.transform.position = new Vector3(-2, transform.position.y, 0);

		//Randomize ball order
		Debug.Log("Ball list has " + billiardBalls.Count + " items");
		Shuffle(billiardBalls);
		Debug.Log("Ball list after shuffle has has " + billiardBalls.Count + " items");
		//List<int> randomizedBalls = Enumerable.Range(1, 15).ToList();

		//Reset billiard ball positions using BST
		BilliardBallBST bst = new BilliardBallBST(billiardBalls, new Vector3(0, transform.position.y, 0));
	}

	//TODO - for now hardcode but after use scale to find true radius
	//https://answers.unity.com/questions/35753/how-do-i-find-the-size-of-a-gameobject.html
	//Right now the radius is wrong because the ball game objects have been scaled
	private float GetBallRadius(GameObject ball)
    {
		Mesh mesh = ball.GetComponent<MeshCollider>().sharedMesh;
		Vector3[] vertices = mesh.vertices;
		return Vector3.Distance(transform.position, vertices[0]);
	}

	//Fisher-Yates Shuffle
	private void Shuffle(List<GameObject> ballList)
	{
		// Loops through array
		for (int i = ballList.Count - 1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0, i);

			// Save the value of the current i, otherwise it'll overright when we swap the values
			GameObject temp = ballList[i];

			// Swap the new and old values
			ballList[i] = ballList[rnd];
			ballList[rnd] = temp;
		}
	}
}
