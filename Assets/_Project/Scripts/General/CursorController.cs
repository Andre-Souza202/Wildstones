using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController Instance; 

    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorQuestionMark;
    [SerializeField] private Texture2D cursorDrag;
    [SerializeField] private Texture2D cursorDialogue;

    private Vector2 cursorPositionMiddle;
    private Vector2 cursorPositionUpLeft;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Found 2 CursorController on scene");
        }
    }

    void Start()
    {
        cursorPositionMiddle = new Vector2(cursorNormal.width / 2, cursorNormal.height / 2);
        cursorPositionUpLeft = Vector2.zero;
    }

    public void CursorToNormal()
    {
        Cursor.SetCursor(cursorNormal, cursorPositionUpLeft, CursorMode.Auto);
    }
    public void CursorToQuestionMark()
    {
        Cursor.SetCursor(cursorQuestionMark, cursorPositionMiddle, CursorMode.Auto);
    }
    public void CursorToDrag()
    {
        Cursor.SetCursor(cursorDrag, cursorPositionMiddle, CursorMode.Auto);
    }
    public void CursorToDialogue()
    {
        Cursor.SetCursor(cursorDialogue, cursorPositionMiddle, CursorMode.Auto);
    }
}
