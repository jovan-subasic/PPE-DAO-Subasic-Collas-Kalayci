using System;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOFactory
    {
        SqlConnection connexion;

        public DAOFactory()
        {
            //connexion = new SqlConnection("Data Source='172.17.21.10';Initial Catalog=SIO2-AgenceBancaire;User ID=SIO2-dev;Password=btssio-slam-2019");
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.IntegratedSecurity = true;
            //builder.InitialCatalog = "asl";
            builder.InitialCatalog = "M2L-ASL";
            Console.WriteLine("Connexion info created : " + builder.ConnectionString);

            connexion = new SqlConnection(builder.ConnectionString);
        }

        public void connecter()
        {
            connexion.Open();

        }

        public void deconnecter()
        {
            connexion.Close();
        }

        // Exécution d'une requête de lecture ; retourne un Datareader
        public SqlDataReader excecSQLRead(string requete)
        {
            SqlCommand maCommand;
            SqlDataAdapter monDataAdapter;
            maCommand = new SqlCommand();
            maCommand.CommandText = requete;
            maCommand.Connection = connexion;

            monDataAdapter = new SqlDataAdapter();
            monDataAdapter.SelectCommand = maCommand;

            SqlDataReader monDR;
            monDR = maCommand.ExecuteReader();

            return monDR;
        }

        // Exécution d'une requete d'écriture (Insert ou Update) ; ne retourne rien
        public void execSQLWrite(string requete)
        {

            SqlCommand maCommand;
            maCommand = new SqlCommand();
            maCommand.CommandText = requete;
            maCommand.Connection = connexion;

            maCommand.ExecuteNonQuery();

        }
    }
}
