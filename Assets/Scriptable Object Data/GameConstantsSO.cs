using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConstantsSO", menuName = "GameConstants", order = 1)]
public class GameConstantsSO : ScriptableObject
{
    // I have this set up like this because a ScriptableObject cannot set const variables from the inspector window
    [SerializeField][Range(1,10)]  private int winningSccore = 10;  // The score for a team to win the game
    public int WINNING_SCORE {get{return winningSccore;}}   
    [SerializeField][Range(1,10)] private int playerMaxHealth = 1;     
    public int PLAYER_MAX_HEALTH {get{return playerMaxHealth;}}     // A players health upon spawning
    [SerializeField] private float iframeTime = 2f;
    public float IFRAME_TIME {get{return iframeTime;}}              // The iFrame (Invicibility frame) time after a player gets hit
    [SerializeField] private float minDamageSpeed = 4f;
    public float MIN_DAMAGE_SPEED {get{return minDamageSpeed;}}     // A ball must be moving at least this fast to damage a player (prevents player from losing health by running into ball on ground)
}
