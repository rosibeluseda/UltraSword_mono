using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    // Class                :   SpriteBatchExtensions
    //
    // Method parameters    :    -
    //
    // Method return        :    -
    //
    // Synopsis             :   This class draws the rectangles for collisions
    //                                            
    //                                    
    // Modifications        :
    //                                            Date            Developer                Notes
    //                                            ----            ---------                -----
    //                                            2023-11-25      Rosibel Useda    
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    public static class SpriteBatchExtensions
    {
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // Method               :   DrawRectangle
        //
        // Method parameters    :   SpriteBatch spriteBatch, Rectangle rectangle, Color color, int thickness = 1
        //
        // Method return        :    -
        //
        // Synopsis             :   This method is the constructor for this class  
        //                                            
        //                                    
        // Modifications        :
        //                                            Date            Developer                Notes
        //                                            ----            ---------                -----
        //                                            2023-11-25      Rosibel Useda    
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public static void DrawRectangle(this SpriteBatch spriteBatch, Rectangle rectangle, Color color, byte thickness = 1)
        {
            Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { color });

            // Draw top
            spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, thickness), color);
            // Draw bottom
            spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Bottom - thickness, rectangle.Width, thickness), color);
            // Draw left
            spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y, thickness, rectangle.Height), color);
            // Draw right
            spriteBatch.Draw(pixel, new Rectangle(rectangle.Right - thickness, rectangle.Y, thickness, rectangle.Height), color);
        }
    }
}
