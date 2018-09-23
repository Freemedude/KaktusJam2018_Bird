using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public DialogueTrigger[] playerDialogue;
    private int playerDialogueIndex = 0;
    public DialogueTrigger[] swanobiDialogue;
    private int swanobiDialogueIndex = 0;

    public bool hasFinished = false;

    DialogueManager dialogueManager;

    public SwanobiController swanobiController;
    private bool sentMessages;

    public void StartStory()
    {
        sentMessages = false;
        if(dialogueManager == null)
        {
            var go = GameObject.Find("DialogueManager");
            dialogueManager = go.GetComponent<DialogueManager>();
        }

        // Ugh Sick of letters
        PlayerTalk();
        
        // Hello there
        SwanobiTalk();

        // Sup
        PlayerTalk();

        // Ur mom dead lul!
        SwanobiTalk();

        // My mom dead unlul?
        PlayerTalk();

        // Shush and climb a tree
        SwanobiTalk();

        // I can't
        PlayerTalk();

        // Do
        SwanobiTalk();

        sentMessages = true;
    }

    private void Update()
    {
        if(dialogueManager == null)
        {
            var go = GameObject.Find("DialogueManager");
            dialogueManager = go.GetComponent<DialogueManager>();
        }

        if(sentMessages && !dialogueManager.dialogueActive)
        {
            swanobiController.WalkOut();
            swanobiController.shouldWalk = true;
            hasFinished = true;
        }
        
    }

    private void PlayerTalk()
    {
        playerDialogue[playerDialogueIndex++].SendMessage("TriggerDialogue");
    }

    private void SwanobiTalk()
    {
        swanobiDialogue[swanobiDialogueIndex++].SendMessage("TriggerDialogue");
    }
    
}