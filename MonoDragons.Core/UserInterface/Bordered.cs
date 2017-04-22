using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public class Bordered : IVisual
    {
        private readonly ISpatial _spatial;

        public Bordered(ISpatial spatial)
        {
            _spatial = spatial;
        }

        public void Draw(Transform2 parentTransform)
        {
            
        }
    }
}
