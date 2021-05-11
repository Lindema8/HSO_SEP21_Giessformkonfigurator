//-----------------------------------------------------------------------
// <copyright file="DBConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Configuration;

namespace Gießformkonfigurator.WindowsForms.DataAccess
{
    /// <summary>
    /// Speichert den connectionString zur Verbindung zur Datenbank.
    /// </summary>
    public static class DBConnection
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["Gießformkonfigurator"].ConnectionString;
    }
}