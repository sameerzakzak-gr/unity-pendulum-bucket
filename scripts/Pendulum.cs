using UnityEngine;
using System.Collections;

public class Pendulum : MonoBehaviour {
	
	public GameObject Pivot;
	public GameObject Bucket;

	public float freq_time = 7.5f;
	public float mass = 1f;
	public float ropeLength = 10f;


    private float tensionForce = 0f;
    private float gravityForce = 0f;
    private float frictionForce = 0f;
    private float t = 0f;
    private float dt = 0.01f;
    private float currentTime = 0f;
    private float accumulator = 0f;

    public Vector3 currentVelocity = new Vector3();
    //to smooth the motion
    Vector3 currentStatePosition;
    Vector3 previousStatePosition;
    Vector3 bucketStartingPosition;

	bool setBucketStartingPosition = false;

	private Vector3 gravityDirection;
    private Vector3 tensionDirection;
	private Vector3 tangentDirection;
	private Vector3 pendulumSideDirection;
    
	void Start ()
    {
		// Set the starting position for later use in the context menu reset methods
		bucketStartingPosition = Bucket.transform.position;
		setBucketStartingPosition = true;
		PendulumInitialize();
	}

    void Update()
    {
        // Fixed deltaTime rendering at any speed with smoothing
        float frameTime = Time.time - currentTime;
        currentTime = Time.time;
        accumulator += frameTime;

        while (accumulator >= dt)
        {
            previousStatePosition = currentStatePosition;
            currentStatePosition = PendulumUpdate(currentStatePosition, dt);
            accumulator -= dt;
            t += dt;
        }
        float deltaTime = accumulator / dt;
        Vector3 newPosition = currentStatePosition * deltaTime + previousStatePosition * (1f - deltaTime);
        Bucket.transform.position = newPosition;
    }


    //[ContextMenu("Reset Pendulum Position")]
	void ResetPendulumPosition()
	{
		if(setBucketStartingPosition)
			MoveBucket(bucketStartingPosition);
		else
			PendulumInitialize();
	}

	
	//[ContextMenu("Reset Pendulum Forces")]
	void ResetPendulumForces()
	{
		currentVelocity = Vector3.zero;
		currentStatePosition = Bucket.transform.position;
	}
	
	void PendulumInitialize()
	{
		//ropeLength = Vector3.Distance(Pivot.transform.position, Bucket.transform.position);
		ResetPendulumForces();
	}
	
	void MoveBucket(Vector3 resetBucketPosition)
	{
		Bucket.transform.position = resetBucketPosition;
		currentStatePosition = resetBucketPosition;
	}


    Vector3 PendulumUpdate(Vector3 currentStatePosition, float deltaTime)
    {
        gravityForce = mass * Physics.gravity.magnitude;
        gravityDirection = new Vector3(0, -1, 0).normalized;

        currentVelocity += gravityDirection * gravityForce * deltaTime;

        Vector3 pivot_position = Pivot.transform.position;
        Vector3 bucket_position = this.currentStatePosition;
        Vector3 MovementDelta = currentVelocity * deltaTime;
        float bucketDistance = Vector3.Distance(pivot_position, bucket_position + MovementDelta);

        // If at the end of the rope
        if (bucketDistance > ropeLength || Mathf.Approximately(bucketDistance, ropeLength))
        {
            tensionDirection = (pivot_position - bucket_position).normalized;
            pendulumSideDirection = (Quaternion.Euler(0f, 90f, 0f) * tensionDirection);
            pendulumSideDirection.Scale(new Vector3(1f, 0f, 1f));
            pendulumSideDirection.Normalize();
            tangentDirection = (-1f * Vector3.Cross(tensionDirection, pendulumSideDirection)).normalized;
            //mel
            float inclinationAngle = Vector3.Angle((bucket_position - pivot_position), gravityDirection);
            frictionForce = mass * Physics.gravity.magnitude * Mathf.Sin(Mathf.Deg2Rad * inclinationAngle);

            float alpha = Vector3.Angle(bucket_position - pivot_position, gravityDirection);
            inclinationAngle = alpha - (frictionForce * freq_time);

            tensionForce = mass * Physics.gravity.magnitude * Mathf.Cos(Mathf.Deg2Rad * inclinationAngle);
            //gravity
            float centripetalForce = ((mass * Mathf.Pow(currentVelocity.magnitude, 2)) / ropeLength);
            tensionForce += centripetalForce;

            currentVelocity += tensionDirection * tensionForce * deltaTime;
        }

        // Get the movement deltaTime
        Vector3 movementDelta = Vector3.zero;
        movementDelta += currentVelocity * deltaTime;

        float distance = Vector3.Distance(pivot_position, currentStatePosition + movementDelta);
        return GetPointOnLine(pivot_position, currentStatePosition + movementDelta, distance <= ropeLength ? distance : ropeLength);
    }
	
	Vector3 GetPointOnLine(Vector3 start, Vector3 end, float distanceFromStart)
	{
		return start + (distanceFromStart * Vector3.Normalize(end - start));
	}
	
	//void OnDrawGizmos()
	//{
	//	// purple
	//	Gizmos.color = new Color(.5f, 0f, .5f);
	//	Gizmos.DrawWireSphere(this.Pivot.transform.position, this.ropeLength);
		
	//	Gizmos.DrawWireCube(this.bucketStartingPosition, new Vector3(.5f, .5f, .5f));
		
		
	//	// Blue: Auxilary
	//	Gizmos.color = new Color(.3f, .3f, 1f); // blue
	//	Vector3 auxVel = .3f * this.currentVelocity;
	//	Gizmos.DrawRay(this.Bucket.transform.position, auxVel);
	//	Gizmos.DrawSphere(this.Bucket.transform.position + auxVel, .2f);
		
	//	// Yellow: Gravity
	//	Gizmos.color = new Color(1f, 1f, .2f);
	//	Vector3 gravity = .3f * this.gravityForce*this.gravityDirection;
	//	Gizmos.DrawRay(this.Bucket.transform.position, gravity);
	//	Gizmos.DrawSphere(this.Bucket.transform.position + gravity, .2f);
		
	//	// Orange: Tension
	//	Gizmos.color = new Color(1f, .5f, .2f); // Orange
	//	Vector3 tension = .3f * this.tensionForce*this.tensionDirection;
	//	Gizmos.DrawRay(this.Bucket.transform.position, tension);
	//	Gizmos.DrawSphere(this.Bucket.transform.position + tension, .2f);
		
	//	// Red: Resultant
	//	Gizmos.color = new Color(1f, .3f, .3f); // red
	//	Vector3 resultant = gravity + tension;
	//	Gizmos.DrawRay(this.Bucket.transform.position, resultant);
	//	Gizmos.DrawSphere(this.Bucket.transform.position + resultant, .2f);
		
	//}
}