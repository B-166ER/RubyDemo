using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2 : BallController
{
    //when ball at a certain distance. make a direct shot
    //rest is pointer can move ball anydirection
    // shot from anyhere makes it really hard to control

    private float startTime;
    private Vector3 startPos;

    [SerializeField] GameObject TargetReObject2;
    [SerializeField] GameObject Vguide;

    public float angleaxisVal = -90f;
    public GameObject TargetRelativeObject;
    public float angleBetweenBallAndTarget;

    ////delsasap
    Vector3 stPos;
    ////delsasap
    Vector3 enPos;

    // swipe actions start and end as vector3
    [SerializeField] Vector3 lastMouseMovement;
    // record last swipe action to be used after ball touches the ground
    [SerializeField] float mouseMovementTime;
    // if time is going to be used 
    [Range(-1,1)][SerializeField] float pushtTimeMultiplier;
    [SerializeField] float angleAxisVal;
    [Range(0, 3)] [SerializeField] float pushBallUpDependingOnMouseY;
    Vector3 forcethatwaitsuntillgroundtouch;
    public float angle;

    void CustomMouseDown()
    {
        TargetReObject2atBase = TargetReObject2;
        //record Time if faster swipe is going to push ball further
        startTime = Time.time;
        startPos = Input.mousePosition;

        ////delsasap
        stPos = startPos;
    }
    void CustomOnMouseUp()
    {
        var endPos = Input.mousePosition;

        var force = endPos - startPos;
        Vector3 mouseRay = endPos - startPos;
        //if you wanna use time
        mouseMovementTime /= (Time.time - startTime);

        // get mouse event lock it on the ball and make it parralel to the ground by quaternian 90- on left or right axis;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + mouseRay, Color.black, 10f);
        Vector3 rotated = Quaternion.AngleAxis(90, gameObject.transform.right) * mouseRay;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + rotated, Color.blue, 10f);


        Vector3 targetDir = TargetReObject2.transform.position - transform.position;
        Vector3 forward = transform.forward;
        angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        angle *= -1;
        Vector3 rotaatedforRelative = Quaternion.AngleAxis(angle, Vector3.up) * rotated;


        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + rotaatedforRelative, Color.yellow, 10f);

        //pointer movement is y&x 
        lastMouseMovement = endPos - startPos;
        lastMouseMovementBase = lastMouseMovement;
        if (lastMouseMovement.y > 0) rotaatedforRelative.y += lastMouseMovement.y * pushBallUpDependingOnMouseY;

        if (GameManager.instance.waitForTouchGroundBeforePush == false) PushTheBall(rotaatedforRelative);
        else 
        { 
            TheForceThatIsWaitingToBeAddedOneRigidBody = rotaatedforRelative;
        }
        oncepush = true;
    }

    
    void Start()
    {
        TargetReObject2atBase = TargetReObject2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CustomMouseDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CustomOnMouseUp();
        }
    }

    // push the ball by the parameter force
    public override void PushTheBall(Vector3 force)
    {
        if (GameManager.instance.isMouseEventTimeRelevant == true)
        {
            Vector3 tmp = Vector3.one;
            tmp *= (mouseMovementTime * pushtTimeMultiplier);
            force = tmp;
            Debug.Log("force :" + force);
            TheForceThatIsWaitingToBeAddedOneRigidBody = force;
        }
        else
        {
            TheForceThatIsWaitingToBeAddedOneRigidBody = force;
        }
    }




}
