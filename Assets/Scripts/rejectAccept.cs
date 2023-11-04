using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class rejectAccept : MonoBehaviour
{
    public int sanity = 10;

    public void choice(bool buttonPress) //BUTTON PRESS: false for rejected individual, true for accepted individual
    {
        attributeList al = GetComponent<attributeList>();
        bool acceptable = al.acceptable;

        if(acceptable == buttonPress){
            sanity++;
            //return true;
        }
        else{
            sanity--;
            //return false;
        }
    }

    void Update(){
        if(sanity <= 0){
            //endgame
        }
    }
}
