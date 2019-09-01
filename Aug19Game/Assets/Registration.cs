using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public InputField NameInputField;
    public InputField PWInputField;
    public Button submitButton;

    public void CallRegister(){
         StartCoroutine(Register()); //call the coroutine, middleway function
    }

    IEnumerator Register(){

        WWWForm form = new WWWForm(); //create a form
        form.AddField("name", NameInputField.text); //add an input field to the form with the text in the name input field on the screen
        form.AddField("password", PWInputField.text); //do the same for password

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form); //create a request object to send from the directories specified, used to access page and get imfo from it
        yield return www; //put this information on hold and once we get it back we can run the rest of the code

        if (www.isNetworkError || www.isHttpError){ //if there is a network or server error, inform
            Debug.Log(www.error);
        }
        else {
            Debug.Log("User created succesfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
    }

    public void VerifyInput(){

        submitButton.interactable = (NameInputField.text.Length >=8 && PWInputField.text.Length >=8); //form validation for username and password, otherwise button will not be interactable
    }
}
