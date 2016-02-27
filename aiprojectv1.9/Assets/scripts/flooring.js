#pragma strict

public var floortiles : GameObject[];
public var floorpositions : Transform[];


function Start() {
  for (var i=0; i < floorpositions.length; i++){
    //Select From Objects To Spawn
    var thingToSpawn : int = Random.Range( 0, floortiles.length );
    Instantiate( floortiles[thingToSpawn], floorpositions[i].position, transform.rotation );
  }
}