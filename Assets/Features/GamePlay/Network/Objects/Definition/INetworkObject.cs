using Ragon.Client;
using UnityEngine;

namespace GamePlay.Network.Objects.Definition
{
    public interface INetworkObject
    {
        RagonEntity Entity { get; }
        GameObject Object { get; }
    }
}