using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace CityExtreme.Base.Gui{
    public class NumTicker:Drawable{
        IntRect bounds;
        public IntRect GlobalBounds{
            get{
                return bounds;
            }
        }
        Text desclabel,numlabel;
        CircleShape minuscir,pluscir,cstepcir;

        RectangleShape minue,plus_v,plus_h,bar;
        public int? min,max,steps,stepamt,id;
        public double? d_min,d_max,d_steps,d_stepamt;
        public NumTicker(Vector2f pos,int _min,int _max,int _stepamt, string desc, int _id){
            bounds = new IntRect((Vector2i)pos,new Vector2i(300,100));
            numlabel = new Text(_min.ToString(),Support.b.defFont,25);
            desclabel = new Text(desc,Support.b.defFont,25);
            id=_id;
            min = _min;
            max=_max;
            stepamt =_stepamt;
            steps = max/stepamt;
            desclabel.Position = new Vector2f((float)bounds.Left,(float)bounds.Top);
            minuscir = new CircleShape(10,10);
            minuscir.Position = new Vector2f(desclabel.Position.X+desclabel.GetGlobalBounds().Width+20,desclabel.Position.Y);
            minuscir.FillColor = Color.Blue;
            bar=new RectangleShape();
            bar.Position =new Vector2f(desclabel.Position.X+desclabel.GetGlobalBounds().Width+20+minuscir.GetGlobalBounds().Width,minuscir.GetGlobalBounds().Height/2);
            bar.Size = new Vector2f(150,20);
        }
        public NumTicker(Vector2f pos,double _min,double _max,double _stepamt, string desc, int _id){

        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new NotImplementedException();
        }
    }
}
