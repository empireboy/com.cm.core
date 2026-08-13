using CM.Core.Domain;

namespace CM.Core.Application
{
    public class GridInteractionUseCase
    {
        public bool TryInteract(Grid grid, IGridEntity entity, GameStateManager gameStateManager)
        {
            Int2 targetPosition = entity.Position + entity.Direction.ToInt2();

            if (!grid.InRange(targetPosition))
                return false;

            GridCell cell = grid.GetCell(targetPosition);

            if (cell.Occupant is not IInteractable interactable)
                return false;

            gameStateManager.ChangeState(GameStates.Dialogue);

            interactable.Interact();

            return true;
        }
    }
}