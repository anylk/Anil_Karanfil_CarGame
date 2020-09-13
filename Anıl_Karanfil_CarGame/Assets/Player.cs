using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;

    public float speed;
    Vector3 velocity;
    private Vector3 inputVector;

    bool isPressedLeft;
    bool isPressedRight;

    Recorder recorder;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        recorder = GetComponent<Recorder>();
        recorder.startingPos = transform.position;
    }

    // Update is called once per frame
    public float timer;
    void Update()
    {

        velocity = Vector3.zero;

        Vector2 mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);




        if (Input.GetMouseButton(0))//Tab the screen
        {

            if (mouse.x < Screen.width / 2)//Left side of screen.
            {
                isPressedLeft = true;
            }

            if (mouse.x > Screen.width / 2)//Right side of screen.
            {
                isPressedRight = true;
            }
        }


        if (Input.GetMouseButtonUp(0))//Stop touch of screen.
        {
            if (isPressedLeft == true)
            {
                recorder.recordDataList.Add(new RecordData(-1, timer, timerPress));

            }
            if (isPressedRight == true)
            {
                recorder.recordDataList.Add(new RecordData(1, timer, timerPress));

            }
            timer = 0;
            timerPress = 0;
            isPressedRight = false;
            isPressedLeft = false;
        }

        


    }

    float timerPress;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (isPressedLeft)
        {
            timerPress += Time.deltaTime;
            MoveHorizontal(-1);
        }


        if (isPressedRight)
        {
            timerPress += Time.deltaTime;
            MoveHorizontal(1);

        }
        MoveVertical();//Car always moves in a positive direction
    }

    public void MoveVertical()//Car always moves in a positive direction
    {
        velocity.z = 10;
        transform.Translate(velocity.normalized * Time.deltaTime * speed);
    }
    public void MoveHorizontal(int charge)//Car moves in a positive or negative direction
    {
        velocity.x = charge;
        transform.Rotate(0, charge * 45 * Time.deltaTime, 0);
    }


}
