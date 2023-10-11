using UnityEngine;

namespace Common.UniversalAnimators.Animations.Abstract
{
    public interface IUpdatableAnimation
    {
        Sprite Update(float delta);
    }
}