using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Outline outline;
    private Color outlineColor;
    [SerializeField] private Color selectedOutlineColor = new Color(0,255,0);
    private float outilineWidth;
    [SerializeField] private float selectedOutilineWidth = 15f;

    [SerializeField] private TextAsset dialogue;
    [SerializeField] private bool isPermanent = false;

    [SerializeField] private string cursorType = "QuestionMark";

    //Temporary sounds
    [SerializeField] private AudioClip hey;
    [SerializeField] private AudioClip hmm;

    public bool isActive = false;

    void Start()
    {
        outline = GetComponent<Outline>();

        outlineColor = outline.outlineColor;
        outilineWidth = outline.outlineWidth;

        Deactive();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isActive)
        {
            ChangeCursorOnPointer(cursorType);
            outline.ChangeOutline(selectedOutilineWidth, selectedOutlineColor);

            switch (cursorType)
            {
                case "QuestionMark":
                    SoundFXManager.instance.PlaySoundFXClip(hmm, transform, 1f);
                    break;

                case "Dialogue":
                    SoundFXManager.instance.PlaySoundFXClip(hey, transform, 0.2f);
                    break;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isActive)
        {
            ChangeCursorOnPointer("Normal");
            outline.ChangeOutline(outilineWidth, outlineColor);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isActive)
        {
            ChangeCursorOnPointer("Normal");

            if (!isPermanent)
            {
                Deactive();
                DialogueManager.Instance.EnterDialogueMode(dialogue);
            }
            else
            {
                DialogueManager.Instance.EnterDialogueMode(dialogue);
            }
        }
    }

    public void Active()
    {
        isActive = true;
        outline.enabled = true;
    }

    public void Deactive()
    {
        isActive = false;
        outline.enabled = false;
    }

    private void ChangeCursorOnPointer(string change)
    {
        if(CursorController.Instance == null)
        {
            return;
        }

        switch(change)
        {
            case "QuestionMark":
                CursorController.Instance.CursorToQuestionMark();
                break;

            case "Dialogue":
                CursorController.Instance.CursorToDialogue();
                break;

            default:
                CursorController.Instance.CursorToNormal();
                break;
        }
    }
}
