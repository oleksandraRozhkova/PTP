using System;

namespace Game.UI
{
    public interface ILevelsMenuView
    {
        event Action OnBackToMainMenuGamePressed;

        event Action OnLevel1ButtonPressed;
    }
}