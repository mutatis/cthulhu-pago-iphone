using UnityEngine;
using System.Collections;

public class CastroTextog : MonoBehaviour {
	
	TextMesh text;
	int gh;
	char let;
	
	string[] texts = new string[] { "1st Assistant Director", "Sound Designer", "2nd Assistant Director", "Additional Assistant Director", "Composer", "2nd 2nd Assistant Directors", "Coreographers", "Visual Effects", "Special Thanks", "Camera Operator", "B Camera Operator", "Camera Loader", "Lead Man", "Swing", "Starcraft Maker", "Costume Supervisor", "John Galt", "Make Up Artist", "Hairstylist", "Beard Stylist", "Feather Stylist", "Antler Stylist", "Tentacle Stylist", "Chicken Supervisor", "Reindeer Supervisor", "Cosmic Evil Summoner N1", "Cosmic Evil Summoner N2", "Dog Walkers", "Re-Recording Mixers", "Dialogue Editors", "Funny Supervisor", "Supervisor Supervisor", "Matress Supplier", "Voice Casting", "Orchestra", "3D Artwork", "Solid Objects", "4D Artwork", "Digital Morphing", "Analog Morphing", "Matte Supplier", "Assistant to Our Lord Cthulhu", "Assistant to Your Highness Dagon", "Assistant to Santa Claus", "Assistant to Elves", "Best Boy Grip", "Dolly Grip A", "Dolly Grip B", "Transporting Co-Captain", "Medic", "Chef A", "Chef B", "Catering", "Gardening Unit", "Stuntman to Our Lord Cthulhu", "Stuntman to Your Highness Dagon", "Stuntman to Santa Claus", "Henchmen", "Elves In Order of Appearance", "Acolytes", "Sledge Manager", "Marlon Brando Look-Alikes", "The Soundtrack", "2nd Unit - Bratislava"};
	
	
	
	// Use this for initialization
	void Start () 
	{
		text = GetComponent<TextMesh>();
		gh = PlayerPrefs.GetInt("Castro");
		if(PlayerPrefs.GetInt("Castro") > texts.Length)
		{
			PlayerPrefs.SetInt("Castro", 0);
			gh = PlayerPrefs.GetInt("Castro");
		}
		else
		{
			gh = PlayerPrefs.GetInt("Castro");
			PlayerPrefs.SetInt("Castro", (gh + 3));
		}
		gh = PlayerPrefs.GetInt("Castro");
		text.text = texts[gh];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}