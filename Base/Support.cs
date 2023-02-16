using SFML.System;
using System;
using SFML.Graphics;
using SFML.Window;
namespace CityExtreme.Base{
    public class Support{
        public static Base b;

        public Support(){
            b = new Base();
            
            b.initMenus(b.w.Settings);
        }
    }
}