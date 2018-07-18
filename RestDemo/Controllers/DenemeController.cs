using FirebirdSql.Data.FirebirdClient;
using RestDemo.Models;
using RestDemo.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace RestDemo.Controllers
{
    public class DenemeController : ApiController
    {

        Connection connection = new Connection();
       
        // GET: api/Deneme
        public IEnumerable<DenemeModel> Get()
        {
            var connectionString = connection.connectionString;
            var denemeModelList = new List<DenemeModel>();
            var sql = "SELECT * FROM STOK";
            try
            {
                /*
                var conn = new FbConnection(connectionString);
                conn.Open();           
                var command = new FbCommand(sql, conn);
                var reader = command.ExecuteReader();
                */
                FbDataReader reader = connection.connFDB(sql);

                while (reader.Read())
                {
                    var denemeModel = new DenemeModel
                    {
                        Blkodu = reader["BLKODU"].ToString(),
                        StokKodu = reader["STOKKODU"].ToString(),
                        StokAdı = reader["STOK_ADI"].ToString()
                    };

                    denemeModelList.Add(denemeModel);
                }
            
            }
            catch (Exception e)
            {
                Console.WriteLine($"Veritabanı Hatası: {e.Message}");
            }

      
            return denemeModelList;
        }

        // GET: api/Deneme/5
        [HttpGet]
        public DenemeModel Get(int id)
        {
            return new DenemeModel
            {
              
            };
        }

        // POST: api/Deneme
        public void Post([FromBody]DenemeModel value)
        {
            try
            {
                string sql = " INSERT INTO STOK(BLKODU,STOKKODU,STOK_ADI) VALUES(" + value.Blkodu +
                        "," + "'" + value.StokKodu +
                        "'," + "'" + value.StokAdı + "')";
                connection.postFDB(sql);

            }
            catch (Exception e)
            {
               
            }

        }

        // PUT: api/Deneme/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Deneme/5
        public void Delete(int id)
        {
        }
    }
}
