using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;
    public Animator animator;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue){

        animator.SetBool("isOpen",true);
        nameText.text = dialogue.name;

        sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
	}

    void EndDialogue()
	{
		animator.SetBool("isOpen",false);
	}

    
   
}
