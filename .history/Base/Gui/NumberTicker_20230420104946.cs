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

        RectangleShape minus,plus_v,plus_h,bar;
        public int? min,max,steps,step,stepamt,id,cstepciroffset;
        public double? d_min,d_max,d_steps,d_stepamt;
        public NumTicker(Vector2f pos,int _min,int _max,int _stepamt, string desc, int _id){
            bounds = new IntRect((Vector2i)pos,new Vector2i(300,100));
            numlabel = new Text(_min.ToString(),Support.b.defFont,25);
            desclabel = new Text(desc,Support.b.defFont,25);
            id=_id;
            min = _min;
            max=_max;
            stepamt =_stepamt;
            steps = (max-min)/stepamt;
            desclabel.Position = new Vector2f((float)bounds.Left,(float)bounds.Top);
            minuscir = new CircleShape(20,20);
            minuscir.Position = new Vector2f(desclabel.Position.X+desclabel.GetGlobalBounds().Width+20,desclabel.Position.Y);
            minuscir.FillColor = Color.Blue;
            minus = new RectangleShape(); 
            int lpos = (int)minuscir.GetGlobalBounds().Left + (int)(minuscir.GetGlobalBounds().Width*.2f);
            minus.Position = new Vector2f(lpos,(bounds.Top) + (minuscir.GetGlobalBounds().Height*.4f));
            minus.FillColor = Color.White;
            minus.Size = new Vector2f((minuscir.GetGlobalBounds().Width*.8f)-(minuscir.GetGlobalBounds().Width*.3f),minuscir.GetGlobalBounds().Height*.1f);
            bar=new RectangleShape();
            bar.Position =new Vector2f(minuscir.GetGlobalBounds().Left+minuscir.GetGlobalBounds().Width,minuscir.GetGlobalBounds().Top + (minuscir.GetGlobalBounds().Height*.3f));
            bar.Size = new Vector2f(150,10);
            cstepcir = new CircleShape(12,12);
            cstepciroffset = 150*(1/steps);
            step=((max-min)/(steps*stepamt));
            cstepcir.FillColor=Color.Blue;
            cstepcir.Position= new Vector2f(bar.Position.X+((float)step*(float)cstepciroffset),bar.GetGlobalBounds().Top - 7 );
            pluscir = new CircleShape(20,20);
            pluscir.Position = new Vector2f(bar.Position.X+bar.GetGlobalBounds().Width,minuscir.Position.Y);
            pluscir.FillColor = Color.Blue;
            plus_h = new RectangleShape();
            plus_h.Position= new Vector2f(pluscir.GetGlobalBounds().Left + (pluscir.GetGlobalBounds().Width *.2f),pluscir.GetGlobalBounds().Top+(pluscir.GetGlobalBounds().Height*.5f));
            plus_h.Size = new Vector2f((pluscir.GetGlobalBounds().Width*.8f)-(pluscir.GetGlobalBounds().Width*.2f),(pluscir.GetGlobalBounds().Height*.1f));


        }
        public NumTicker(Vector2f pos,double _min,double _max,double _stepamt, string desc, int _id){

        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(desclabel);
            target.Draw(minuscir);
            target.Draw(minus);
            target.Draw(bar);
            target.Draw(cstepcir);
            target.Draw(pluscir);
            target.Draw(plus_h);
        }
    }
}
