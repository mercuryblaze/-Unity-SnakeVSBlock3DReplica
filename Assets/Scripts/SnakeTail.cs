using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;
    public float CollisionInterval = 0.2f;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    private float collisionTimer = 0;

    void Start()
    {
        positions.Add(SnakeHead.position);
        AddCircle();

    }

    void Update()
    {
        collisionTimer -= Time.deltaTime;

        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        int lastIndex = snakeCircles.Count - 1;
        
        if (snakeCircles.Count == 0)
        {
            //Здесь проигрываем
            Destroy(gameObject);
        }
        else
        {
            Destroy(snakeCircles[lastIndex].gameObject);
            snakeCircles.RemoveAt(lastIndex);
            positions.RemoveAt(lastIndex+1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Pickup pickup))
        {
            for (int i = 0; i < pickup.Amount; i++)
            {
                AddCircle();
            }
            
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (collisionTimer <= 0 && other.gameObject.TryGetComponent(out Block block))
        {
            block.ApplyDamage();
            RemoveCircle();
            collisionTimer = CollisionInterval;
        }
    }
}
