﻿//-----------------------------------------------------------------------
// <copyright file="MGießform.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Gießformen
{
    using System;
    using Gießformkonfigurator.WindowsForms.DataAccess;
    public class MGießform : Gießform
    {
        private MGießform mGießform;

        public Grundplatte Grundplatte{ get; set; }

        public Ring Fuehrungsring { get; set; }

        public Einlegeplatte Einlegeplatte { get; set; }

        public Kern Innenkern { get; set; }

        public MGießform()
        {  

        }
    }
}
