using System;

namespace Game.UI
{
    public interface IPauseMenuView
    {
        event Action OnBackToGameButtonPressed;

        event Action OnMainManuButtonPressed;
    }
}
