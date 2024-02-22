using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Strategy
{
    public interface IManeuverBehavior
    {
        void Maneuver(Drone drone);
    }
}
