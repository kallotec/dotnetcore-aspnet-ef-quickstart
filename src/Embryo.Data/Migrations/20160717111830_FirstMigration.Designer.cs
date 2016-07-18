using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Embryo.Data.Contexts;

namespace Embryo.Data.Migrations
{
    [DbContext(typeof(SqlEfContext))]
    [Migration("20160717111830_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Embryo.Data.Models.Post", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Content");

                    b.Property<bool>("IsPublished");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });
        }
    }
}
