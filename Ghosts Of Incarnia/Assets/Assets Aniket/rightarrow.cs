using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstHint;
    public GameObject secondHint;
    public GameObject thirdHint; 
    public GameObject larrow;

    int flag;
    void Start()
    {
        flag=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void rightArrow()
{
    firstHint.SetActive(false);
    secondHint.SetActive(true);
    
    flag++;
    // Check if the secondHint is active
    if (flag == 2)
    {
        secondHint.SetActive(false);
        thirdHint.SetActive(true);
    }
}



    public void leftArrow(){
        if(secondHint.activeSelf){
            larrow.SetActive(true);
        }
        if (secondHint.activeSelf){
            secondHint.SetActive(false);
            firstHint.SetActive(true);
        }
        else if (thirdHint.activeSelf){
            thirdHint.SetActive(false);
            secondHint.SetActive(true);
        }
    }

}
