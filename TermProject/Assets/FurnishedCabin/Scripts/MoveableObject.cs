using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour 
{

    public int objectNumber = 1;

    private AudioSource audioSource;
    private GameObject player;
    private PlayerMove playerMove;
    private bool bathroomSoundPlayed = false;
	private bool bedroomSoundPlayed = false;
	private bool houseSoundPlayed = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMove>();
        // audio source name is "KeyPick"
        audioSource = GameObject.Find("KeyPick").GetComponent<AudioSource>();
    }

    // if player haveBathroomKey, haveBedroomKey or haveKitchenKey is true, play sound
    public void LateUpdate()
    {
		
		if ( (playerMove.haveBathroomKey && !bathroomSoundPlayed)|| (playerMove.haveBedroomKey && !bedroomSoundPlayed) || (playerMove.haveHouseKey && !houseSoundPlayed))
        {
			if (playerMove.haveBathroomKey)
			{
				bathroomSoundPlayed = true;
                 audioSource.Play();
			} else if (playerMove.haveBedroomKey)
			{
				bedroomSoundPlayed = true;
                 audioSource.Play();
			} else if (playerMove.haveHouseKey)
			{
				houseSoundPlayed = true;
                 audioSource.Play();
			}
        }
    }
} 