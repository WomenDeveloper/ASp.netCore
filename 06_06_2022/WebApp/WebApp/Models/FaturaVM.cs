namespace WebApp.Models
{
    public class FaturaVM
    {
        public Musteri Musteri { get; set; }
        public Fatura Fatura { get; set; }
        public List<FaturaDetay> FaturaDetaylari { get; set; }
    }
}
