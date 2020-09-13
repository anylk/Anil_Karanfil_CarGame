/*-
using System.Collections;
using UnityEngine;

public class ReadRecorder : MonoBehaviour
{
    public Recorder record;
    public float timer;
    Player player;
    public int counter;
    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        record = gameObject.GetComponent<Recorder>();
        transform.position = record.StartPos();
        counter = record.keycodeInput.Count-1;
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;

            if (record.timerInput[counter] == timer)
            {
                Debug.Log(record.keycodeInput[counter]+"   "+ record.pressTime[counter]);

                StartCoroutine(PressKey(record.keycodeInput[counter], record.pressTime[counter]));
            }
        }



    IEnumerator PressKey(string keyCode,float time)
    {

        float enumTimer = 0;
        Vector3 inputVector;

        counter--;


        while (enumTimer-time <= 0)
        {

            if (keyCode=="A")
            {
                inputVector = new Vector3(-1 * player.speed, player.rb.velocity.y, player.speed);
                transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
                player.rb.velocity = inputVector;
            }
            else
            {
                inputVector = new Vector3(1 * player.speed, player.rb.velocity.y, player.speed);
                player.transform.LookAt(player.transform.position + new Vector3(inputVector.x, 0, inputVector.z));
                player.rb.velocity = inputVector;

            }
            enumTimer += Time.deltaTime;


        }


        yield return new WaitForSeconds(time);

        enumTimer = 0;
    }

}
*/