namespace Develop
{
    public class Cars
    {
        public Cars(string model, string mpg, string cyl, string disp, string hp, string drat, string wt, string qsec, string vs, string am, string gear, string carb)
        {
            this.model = model;
            this.mpg = float.Parse(mpg);
            this.cyl = Int32.Parse(cyl);
            this.disp = float.Parse(disp);
            this.hp = Int32.Parse(hp);
            this.drat = float.Parse(drat);
            this.wt = float.Parse(wt);
            this.qsec = float.Parse(qsec);
            if(Int32.Parse(vs) == 0)
            {
                this.vs = false;
            } else
            {
                this.vs = true;
            }

            if (Int32.Parse(am) == 0)
            {
                this.am = false;
            }
            else
            {
                this.am = true;
            }

            this.gear = Int32.Parse(gear);
            this.carb = Int32.Parse(carb);
        }

        public String model { get; set; }
        public float mpg { get; set; }
        public int cyl { get; set; }
        public float disp { get; set; }
        public int hp { get; set; }
        public float drat { get; set; }
        public float wt { get; set; }
        public float qsec { get; set; }
        public bool vs { get; set; }
        public bool am { get; set; }
        public int gear { get; set; }
        public int carb { get; set; }
    }

}
