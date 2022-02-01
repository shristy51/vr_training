using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
		Quaternion m_MyQuaternion;
        public float speed = 5;
        float distanceTravelled;

        void Start() {
			m_MyQuaternion = new Quaternion();
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
				//var step = speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
				//transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
				
				//Vector3 newDirection = Vector3.RotateTowards(transform.forward, pathCreator.path.GetDirectionAtDistance(distanceTravelled, endOfPathInstruction), step, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
                //transform.rotation = Quaternion.LookRotation(newDirection);
				
				
				//m_MyQuaternion.SetFromToRotation(transform.position, pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction));
				//transform.rotation = m_MyQuaternion * transform.rotation;
				
				
				
				
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}