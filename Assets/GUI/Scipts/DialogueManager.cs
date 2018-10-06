using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    //Character Attributes
	public Text nameText;
	public Text dialogueText;

    //Motion animation
	public Animator animator;

    //Where all sentences the NPC are stored
	public Queue<string> sentences;

	// Use this for initialization
	void Start () {
        //Is primed for conversation to start
		sentences = new Queue<string>();
	}

    //When triggered, has dialogue appear
	public void StartDialogue (Dialogue dialogue){
        //switches the animation position to on the screen
		animator.SetBool ("Conversation", true);

		Debug.Log ("Starting conversation with " + dialogue.name);

        //makes the text equal to the name of the character speaking
		nameText.text = dialogue.name;

        //gets rid of any prior sentences leaded
		sentences.Clear ();

		foreach (string sentence in dialogue.sentences){
            //place all sentences in a queue
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}
	public void DisplayNextSentence(){
        //ends dialogue when there are no more sentences
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}
        //returns and removes sentence at top of queue
		string sentence = sentences.Dequeue ();
		dialogueText.text = sentence;
		Debug.Log (sentence);

	}

	public void EndDialogue(){
		animator.SetBool ("Conversation", false);
		Debug.Log ("End of Conversation.");
	}

}
