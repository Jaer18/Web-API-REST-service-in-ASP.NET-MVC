﻿using Clientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Clientes.Data
{
    public class ClienteDB : DbContext
    {
        public ClienteDB(DbContextOptions<ClienteDB> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
