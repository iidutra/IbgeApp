﻿// <auto-generated />
using IbgeApp.API.Excel.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IbgeApp.API.Excel.Migrations
{
    [DbContext(typeof(MunicipioContext))]
    partial class MunicipioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IbgeApp.API.Excel.Model.Municipio", b =>
                {
                    b.Property<int>("CodigoMunicipio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodigoMunicipio"));

                    b.Property<int>("CodigoUF")
                        .HasColumnType("integer");

                    b.Property<string>("NomeMunicipio")
                        .HasColumnType("text");

                    b.HasKey("CodigoMunicipio");

                    b.ToTable("Municipios");
                });
#pragma warning restore 612, 618
        }
    }
}
