using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInfoHolder : MonoBehaviour
{
    public static DialogueInfoHolder Instance;
    [SerializeField] private TextAsset loadGlobaJSON;
    public DialogueVariables dialogueVariables;



    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            dialogueVariables = new DialogueVariables(loadGlobaJSON);
        }
    }

    public void ResetAllVariables()
    {
        dialogueVariables = new DialogueVariables(loadGlobaJSON);
    }
}
