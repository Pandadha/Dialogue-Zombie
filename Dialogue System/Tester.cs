using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

 public Conversation[] convo;
    private void Start()
    {
        StartConvo();
    }
    public void StartConvo() //start
    {
        DialogueManager.StartConversation(convo[0]);
    }
    public void Convo2()// found weapon
    {
        DialogueManager.StartConversation(convo[1]);
    }
    public void Convo3() // doctor mushroom
    {
        DialogueManager.StartConversation(convo[2]);
    }
    public void Convo4()
    {
        DialogueManager.StartConversation(convo[3]);
    }
}
