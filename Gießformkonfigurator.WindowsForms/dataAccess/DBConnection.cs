//-----------------------------------------------------------------------
// <copyright file="DBConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.DataAccess
{
    using System.Configuration;
    using System.Data.Entity;
    /// <summary>
    /// Speichert den connectionString zur Verbindung zur Datenbank.
    /// </summary>
    public class DBConnection : DbContext
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["Gießformkonfigurator"].ConnectionString;

        public DBConnection(): base()
        {

        }



    }
}