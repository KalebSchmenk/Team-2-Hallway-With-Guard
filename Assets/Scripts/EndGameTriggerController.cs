using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTriggerController : MonoBehaviour
{
    [SerializeField] GameObject winUIParent;
    [SerializeField] float _sendToMenuIn = 2.5f;
    public AudioSource winMusic;
    public AudioClip winSound;
    private bool winSoundPlayed = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerScript = other.gameObject.GetComponent<playerController>();

            if (playerScript.hasCrown == true)
            {
                playerScript._wonGame = true;
                if(winSoundPlayed == false){
                    winMusic.PlayOneShot(winSound);
                }

                winUIParent.SetActive(true);
                StartCoroutine(AwaitSendToMainMenu());
            }
        }
    }

    private IEnumerator AwaitSendToMainMenu()
    {
        yield return new WaitForSeconds(_sendToMenuIn);

        // RE-IMPLEMENT THIS ON MAIN BUILD!
        SceneManager.LoadScene("MainMenu");
        // DELETE THIS FOR MAIN BUILD!
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
