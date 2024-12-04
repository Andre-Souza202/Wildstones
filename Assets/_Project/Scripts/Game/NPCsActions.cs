using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsActions : MonoBehaviour
{
    private DetectMouseHover interactable;
    private Animator anim;

    private bool isMoving = false;
    private int interactionIndex = 0;

    private Transform currentTarget;

    public float speed = 0.5f;

    [System.Serializable]
    public struct Interaction
    {
        public string action;
        public float time;
        public Transform positionToMove;
    }

    public Interaction[] interactions;

    void Start()
    {
        interactable = GetComponent<DetectMouseHover>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (interactions.Length > 0)
        {
            NPCsAndTimeManager.onSecondPassed += CheckInteraction;
        }
    }

    private void OnDisable()
    {
        NPCsAndTimeManager.onSecondPassed -= CheckInteraction;
    }

    void Update()
    {
        if(!isMoving)
        {
            return;
        }

        float step = speed * Time.deltaTime;
        transform.LookAt(currentTarget, Vector3.zero);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.001f)
        {
            isMoving = false;
            anim.SetBool("Movendo", false);
        }
    }


    void CheckInteraction(int time)
    {
        if (time >= interactions[interactionIndex].time)
        {
            //Interact
            switch(interactions[interactionIndex].action)
            {
                case "Ativar":
                    interactable.Active();
                    break;

                case "Desativar":
                    interactable.Deactive();
                    break;

                case "Mover":
                    currentTarget = interactions[interactionIndex].positionToMove;
                    isMoving = true;
                    anim.SetBool("Movendo", true);
                    break;
            }

            interactionIndex++;

            if(interactionIndex >= interactions.Length)
            {
                NPCsAndTimeManager.onSecondPassed -= CheckInteraction;
            }
        }
    }

}
