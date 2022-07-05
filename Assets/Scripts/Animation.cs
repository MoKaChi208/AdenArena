using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public string idleAnimation = "LastMoveX";
    public string moveAnimation = "MoveX";
    enum State
    {
        IDLE, WALKING, DEAD
    }
    private State state = State.IDLE;
    [SerializeField]
    private Animator anim;

    private Vector3 moveX;
    private Vector3 LastMoveX;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

}
