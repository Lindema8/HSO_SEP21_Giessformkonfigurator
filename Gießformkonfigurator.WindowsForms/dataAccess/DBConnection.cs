//-----------------------------------------------------------------------
// <copyright file="DBConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.DataAccess
#pragma warning restore SA1633 // File should have header
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Verbindung zur DB, modelliert als Singleton, um zu jedem Zeitpunkt nur eine Verbindung zur DB zu erlauben.
    /// Die Verbindungsparameter sind als Objektattribute hinterlegt.
    /// </summary>
    public class DBConnection
    {
        private static DBConnection instance = null;
        private SqlConnection connection = null;
        private string server;
        private string db;
        private string user;
        private string password;
        private string connectionProperties;

        private DBConnection()
        {
            // Intentionally nothing.
        }

        /// <summary>
        /// Methode zur Rückgabe des DBConnection-Objekts.
        /// </summary>
        /// <returns>DBConnection instance.</returns>
        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }

            return instance;
        }

        /// <summary>
        /// Methode ermöglicht das setzen der Verbindunginformationen bei Anwendungsstart. Die übergebenen Informationen werden als Objektattribute gespeichert.
        /// Der Kosntruktur stellt eine Erweiterung für die GUI Funktionalität dar und ist bei Konsolen-Anwendungen vollständig null.
        /// </summary>
        /// <param name="server"> IP-Adresse des Servers.</param>
        /// <param name="db">Name der Datenbank.</param>
        /// <param name="user">Anmelde-ID.</param>
        /// <param name="password">Passwort.</param>
        public void SetConnectionDetails(string server, string db, string user, string password)
        {
            Console.WriteLine("Gebe andere Verbindungsinformationen an!");
            Console.Write("IP-Adresse: ");
            this.server = Console.ReadLine();
            Console.Write("Datenbank: ");
            this.db = Console.ReadLine();
            Console.Write("Username: ");
            this.user = Console.ReadLine();
            Console.Write("Password: ");
            this.password = Console.ReadLine();
        }

        /// <summary>
        /// Methode zum Aufbau einer Verbindung zum SQL-Server. Der Connection-String setzt sich aus den Objektattributen zusammen.
        /// Verbindungsversuch wird durchgeführt, falls schon Verbindungsinformationen eingetragen sind - sonst werden sie erfragt.
        /// Wenn noch keine Verbindung besteht oder eine bestehende Verbindung noch nicht offen ist, wird die Verbindung hergestellt.
        /// </summary>
        public void EstablishConnection()
        {
            if (this.server == null)
            {
                this.SetConnectionDetails(null, null, null, null);
                this.EstablishConnection();
            }
            else
            {
                if (this.connection == null
                    || this.connection.State.ToString() != "open")
                {
                    try
                    {
                        this.connectionProperties = @"Data Source=" + this.server + ";Initial Catalog=" + this.db + ";User ID=" + this.user + ";Password=" + this.password + ";";
                        Console.WriteLine("Verbindung wird aufgebaut...!");
                        this.connection = new SqlConnection(this.connectionProperties);
                        this.connection.Open();
                        Console.WriteLine("Connection Open!");
                        Console.ReadLine();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        this.SetConnectionDetails(null, null, null, null);
                        this.EstablishConnection();
                    }
                }
            }
        }

        /// <summary>
        /// Prüft die Verbindung zur SQL-Datenbank bevor weitere Anfragen gestellt werden.
        /// </summary>
        /// <returns>True wenn Verbindung besteht.</returns>
        public bool CheckConnection()
        {
            if (this.connection?.State.ToString() == "Open")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Methode trennt die Verbindung zur DB. Nutzung ist tbd.
        /// </summary>
        public void DisconnectConnection()
        {
            if (this.connection.State.ToString() == "Open")
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Ermöglicht das Hinzufügen eines Datenstrings zu einer Tabelle.
        /// </summary>
        /// <param name="table">Vollständiger Name der Tabelle.</param>
        /// <param name="insertion">Datensatz, welcher hinzugefügt werden soll.</param>
        public void AddData(string table, string insertion)
        {
            string insertString = "INSERT INTO [dbo].[" + table + "] VALUES (" + insertion + ");";
            new SqlCommand(insertString, this.connection);
        }

        /// <summary>
        /// Führt "Select * From Table" auf die übergebene Tabelle aus.
        /// </summary>
        /// <param name="table"> Tabelle zu welcher Daten hinzugefügt werden sollen.</param>
        public void GetAllDataFromTable(string table)
        {
            SqlCommand query;
            SqlDataReader dataReader;
            string queryString, output = string.Empty;

            queryString = "Select * From [" + table + "]";
            query = new SqlCommand(queryString, this.connection);
            dataReader = query.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    output = output + "  " + dataReader.GetValue(i);
                }
            }

            Console.WriteLine(output);
        }
    }
}
