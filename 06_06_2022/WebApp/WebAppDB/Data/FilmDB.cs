using System.Data.SqlClient;
using WebAppDB.Models;

namespace WebAppDB.Data
{
    public class FilmDB
    {
        SqlConnection Conn;
        public FilmDB()
        {
            Conn = new SqlConnection("Data source=.;initial catalog=FilmDB;integrated security=true");
        }

        public List<Film> TumFilmler() {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Filmler", Conn);

            SqlDataReader dr = cmd.ExecuteReader();

            List<Film> filmler = new List<Film>();
            while (dr.Read())
            {
                Film film = new Film() {
                    FilmID = Convert.ToInt32(dr[0]),
                    FilmAdi = dr["FilmAdi"].ToString(),
                    Sure = dr.GetInt32(2),
                    KatID = dr.GetInt32(3)

                };

                filmler.Add(film);
            }

            Conn.Close();
            return filmler;

        }

        public List<Kategori> TumKategoriler()
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kategoriler", Conn);

            SqlDataReader dr = cmd.ExecuteReader();

            List<Kategori> kategoriler = new List<Kategori>();
            while (dr.Read())
            {
                Kategori kategori = new Kategori()
                {
                    KatID = Convert.ToInt32(dr[0]),
                    KategoriAdi = dr["KategoriAdi"].ToString()
                };

                kategoriler.Add(kategori);
            }

            Conn.Close();
            return kategoriler;
        }

        public void  FilmEkle(Film film)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Filmler VALUES(@ad,@sure,@katID)", Conn);

            cmd.Parameters.AddWithValue("@ad", film.FilmAdi);
            cmd.Parameters.AddWithValue("@sure", film.Sure);
            cmd.Parameters.AddWithValue("@katID", film.KatID);

            cmd.ExecuteNonQuery();
            Conn.Close();
        }
    }
}
