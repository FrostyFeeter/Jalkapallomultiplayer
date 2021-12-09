using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class Ball : MonoBehaviourPunCallbacks
{
    public TMP_Text blueTeamText;
    public TMP_Text redTeamText;
    public int teamBlueScore = 0;
    public int teamRedScore = 0;
    Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void UpdateScoreText()
    {
        teamRedScore = (int)PhotonNetwork.CurrentRoom.CustomProperties["RedScore"];       
        teamBlueScore = (int)PhotonNetwork.CurrentRoom.CustomProperties["BlueScore"];   

        redTeamText.text = "Team Red:" + teamRedScore;    
        blueTeamText.text = "Team Blue:" + teamBlueScore;    

    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        UpdateScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 startPoint = new Vector3(0, 1, 0);

        if(other.tag == "BlueGoal")
        {
            teamRedScore += 1;
            PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() {{"RedScore",teamRedScore}});
        }
        if(other.tag == "RedGoal")
        {
            teamBlueScore += 1;
            PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() {{"BlueScore",teamBlueScore}});

        }
        transform.position = startPoint;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
