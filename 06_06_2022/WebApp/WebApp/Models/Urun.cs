namespace WebApp.Models
{
    public class Urun
    {
        public int  UrunID { get; set; }
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }

        public string Renk { get; set; }
        //Polymorphism Yontemi..
        //public override string ToString()
        //{
        //    return $"{UrunID} {UrunAdi} {Fiyat}";
        //}
    }
}
