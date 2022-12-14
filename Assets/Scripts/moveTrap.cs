using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrap : MonoBehaviour
{
    private float rotDegr;
    public GameObject p1, p2;
    public float speed;
    private Vector2 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos=p1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RotationTrap();
        MovingTrap();
    }

    private void RotationTrap(){
        rotDegr = rotDegr + Time.deltaTime*600;
        transform.rotation = Quaternion.Euler(0,0,rotDegr);
    }

    private void MovingTrap(){
        if(transform.position == p1.transform.position){
            nextPos = p2.transform.position;
        }
        if(transform.position == p2.transform.position){
            nextPos = p1.transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position,nextPos, speed*Time.deltaTime);

    }
}
