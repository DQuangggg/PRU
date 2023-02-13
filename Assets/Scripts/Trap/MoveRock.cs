using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRock : MonoBehaviour
{
    public float xDistanceToMainCharacter;
    public float xMoveDistance;
    public float yMoveDistance;

    public Vector3 destination;

    void Start()
    {
        destination = new Vector3(this.gameObject.transform.position.x + xMoveDistance, this.gameObject.transform.position.y + yMoveDistance);
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //float dis = Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x);
        //Debug.Log(dis);
        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < xDistanceToMainCharacter)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 3);
        }
    }
}
