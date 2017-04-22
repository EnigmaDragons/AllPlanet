using Microsoft.Xna.Framework;

namespace MonoDragons.Core.UserInterface
{
    public abstract class ClickableUIElement
    {
        public abstract void OnEntered();
        public abstract void OnExitted();
        public abstract void OnPressed();
        public abstract void OnReleased();
        
        public Vector2 ParentLocation { get; set; }
        public Rectangle Area { get; }

        protected ClickableUIElement(Rectangle area)
        {
            Area = area;
            ParentLocation = new Vector2(0, 0);
        }
    }
}
