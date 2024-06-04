using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ReviveButton : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	public void RevivePlayer()
	{
		gameManager.RevivePlayer();
	}
}
