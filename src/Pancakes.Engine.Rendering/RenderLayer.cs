using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Rendering
{
    /// <summary>
    /// An enumeration of screen layers.  Each layer represents a logical grouping of varying depths (away from player -> towards player).
    /// Further sorting between <see cref="IRendering"/> in the same rendering layer can be done using its DepthWithinRendering property. 
    /// Some layers may have special effects applied to them, such as parralax scrolling.
    /// </summary>
    public enum RenderLayer
    {
        /// <summary>
        /// Furthest layer going into the screen.  It renders with parrallax scrolling and thus should only
        /// be used in situations such as background scenery in a side scroller.
        /// </summary>
        Background,  

        /// <summary>
        /// Layer behind the gameground.  Usually used for rendering static level components in a side scroller
        /// or the ground in a top down.
        /// </summary>
        MidgroundBack,

        /// <summary>
        /// Layer where dynamic game components should be rendered.
        /// </summary>
        Gameground,

        /// <summary>
        /// Layer in front of the gameground.  Can be used to add depth to static level components.  For example, bushes that render
        /// in front of the character in a side scroller, or overhead light in a top down.
        /// </summary>
        MidgroundFront,

        /// <summary>
        /// Layer that will appear very close to the camera.  It renders with parrallax scrolling.  Take a look at Limbo for 
        /// an idea of what this would look like.
        /// </summary>
        Foreground,

        /// <summary>
        /// Special layer where everything renders independently of the camera (aka at a fixed screen position).  Nothin will render
        /// above this level.  It is ideal for creating HUDs and in-game menus.  In future versions of Pancakes this may be
        /// replaced by a UI toolkit.
        /// </summary>
        UI,

        /// <summary>
        /// A special layer that doesn't render.  The main purpose of this layer is to have a place to put 
        /// <see cref="NullRendering"/> so they don't clog up other layers and affect sort time.
        /// </summary>
        NoRender
    }
}
