using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestDemo.Repostories
{
    public class Connection
    {

        //Dikkat bu bölümde dosya yolunu belirteceksiniz
        public string connectionString = "User ID=sysdba;Password=masterkey;" +
                                    @"Database=localhost:C:\Dosya yolu belirtilecek;" +
                                    "Charset=NONE;";
        public string connectionLogin = "User ID=sysdba;Password=masterkey;" +
                                    @"Database=localhost:C:\Dosya yolu belirtilecek;" +
                                    "Charset=NONE;";

        //firebird veritabanına bağlanmak için
        public FbDataReader connFDB(string sql)
        {

            var conn = new FbConnection(connectionString);
            conn.Open();
            var command = new FbCommand(sql, conn);
            var reader = command.ExecuteReader();

            return reader;
        }

        //firebird veritabanına ekleme yapmak için
        public void postFDB(string sql)
        {
            FbConnection addDetailsConnection = new FbConnection(connectionString);
            addDetailsConnection.Open();

            FbTransaction addDetailsTransaction =addDetailsConnection.BeginTransaction();
            FbCommand addDetailsCommand = new FbCommand(sql,
            addDetailsConnection, addDetailsTransaction);
            addDetailsCommand.ExecuteNonQuery();
            addDetailsTransaction.Commit();
        }

    }
}