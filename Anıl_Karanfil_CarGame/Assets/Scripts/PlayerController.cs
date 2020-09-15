using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 velocity;
    public float speed;
    public bool firstTouch=false;



    void Update()
    {
        velocity = Vector3.zero;
        Vector2 mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);//Mouse Input


        if (Input.GetMouseButton(0))//Tab the screen
        {
            firstTouch = true;

            if (firstTouch && !SceneManager.instance.isPlaying)
            {
                SceneManager.instance.StartWithTouch(this);

            }

            if (mouse.x < Screen.width / 2)//Left side of screen.
            {
                MoveHorizontal(-1);

            }

            if (mouse.x > Screen.width / 2)//Right side of screen.
            {
                MoveHorizontal(1);
            }
        }
        if (!firstTouch)
        {
            return;
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

