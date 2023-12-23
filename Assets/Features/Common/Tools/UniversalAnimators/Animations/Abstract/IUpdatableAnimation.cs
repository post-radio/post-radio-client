using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animations.Abstract
{
    public interface IUpdatableAnimation
    {
        Sprite Update(float delta);
    }
}