﻿using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Numerics;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<GenreTypes>? GenreTypes { get; set; }
        public DbSet<Countries>? Countries { get; set; }
        public DbSet<Languages>? Languages { get; set; }
        public DbSet<ContentTypes>? ContentTypes { get; set; }
        public DbSet<RoleTypes>? RoleTypes { get; set; }
        public DbSet<Plans>? Plans { get; set; }
        public DbSet<UserAccounts>? UserAccounts { get; set; }
        public DbSet<Studios>? Studios { get; set; }
        public DbSet<Persons>? Persons { get; set; }
        public DbSet<Contents>? Contents { get; set; }
        public DbSet<ContentGenres>? ContentGenres { get; set; }
        public DbSet<Seasons>? Seasons { get; set; }
        public DbSet<Episodes>? Episodes { get; set; }
        public DbSet<Reviews>? Reviews { get; set; }
        public DbSet<Subscriptions>? Subscriptions { get; set; }
        public DbSet<AudioTracks>? AudioTracks { get; set; }
        public DbSet<Subtitles>? Subtitles { get; set; }
        public DbSet<Watchlists>? Watchlists { get; set; }
        public DbSet<PersonTypeRoles>? PersonTypeRoles { get; set; }
        public DbSet<Credits>? Credits { get; set; }
    }
}