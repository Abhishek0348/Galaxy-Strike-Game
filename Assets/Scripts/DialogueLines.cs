using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] Dialogues;
    [SerializeField] TMP_Text dialogueText;

    int currentLine = 0;

    public void NextDialogue()
    {
        currentLine++;
        dialogueText.text = Dialogues[currentLine];
    }
}
