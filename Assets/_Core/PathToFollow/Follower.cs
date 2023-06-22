using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    [SerializeField] float speed;
    float distanceTravelled;

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}