namespace ConsoleApplication1
{
    public class Car
    {
        private string color;
        
        public string getColor() {return color;}
        
        public void setColor(string color) {this.color = color;}

        public Car()
        {
            color = "red";
        }
    }
}