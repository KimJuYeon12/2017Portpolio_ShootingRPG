using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Player
{ 
public class GravityShot : FireShot
{
    public GravityShot(GameObject ShotSpawnPoint, GameObject Gravity_Set)
    :base(ShotSpawnPoint,Gravity_Set){}

}

}