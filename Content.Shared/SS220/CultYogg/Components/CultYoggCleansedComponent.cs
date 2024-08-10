// © SS220, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/SerbiaStrong-220/space-station-14/master/CLA.txt
using Robust.Shared.GameStates;
using System.Numerics;

namespace Content.Shared.SS220.CultYogg.Components;

[RegisterComponent, NetworkedComponent]
public sealed partial class CultYoggCleansedComponent : Component
{
    /// <summary>
    /// The random time between incidents, (min, max).
    /// </summary>
    public Vector2 TimeBetweenIncidents = new Vector2(0, 5); //ToDo maybe add some damage or screams? should discuss

    public float BeforeDeclinesTime = 500;//ToDo maybe it should be elsewere

    public float AmountOfHolyWater = 0;

    public float AmountToCleance = 10;
}
