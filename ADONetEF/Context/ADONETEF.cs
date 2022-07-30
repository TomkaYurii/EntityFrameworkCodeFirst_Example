using ADONetEF.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetEF.Context
{
    internal class ADONETEF : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public ADONETEF()
        {
            Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TestDbEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                      .HasMany(team => team.Members)
                      .WithMany(user => user.Teams)
                      .UsingEntity(entity =>
                      {
                          entity.ToTable("TeamsMembers");
                          entity.Property("MembersId").HasColumnName("AspNetUserId");
                          entity.Property("TeamsId").HasColumnName("TeamId");
                      });



            modelBuilder.Entity<Team>()
                    .HasOne(team => team.Leader)
                    .WithMany(u => u.Teamsnavigation)
                    .HasForeignKey(team => team.LeaderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Teams_LeaderId");



            //modelBuilder.Entity<Ticket>()
            //       .HasOne(ticket => ticket.Project)
            //       .WithMany(project => project.Tickets)
            //       .HasForeignKey(ticket => ticket.ProjectId)
            //       .OnDelete(DeleteBehavior.Cascade)
            //       .HasConstraintName("FK_Tickets_ProjectId");
            //modelBuilder.Entity<Ticket>()
            //       .HasOne(ticket => ticket.Executor)
            //       .WithMany(user => user.Tickets)
            //       .HasForeignKey(ticket => ticket.ExecutorId)
            //       .OnDelete(DeleteBehavior.SetNull)
            //       .HasConstraintName("FK_Tickets_ExecutorId");


            //modelBuilder.Entity<Rating>()
            //      .HasAlternateKey(rating => new { rating.FromId, rating.ToId })
            //      .HasName("AK_Ratings_FromId_ToId");

            modelBuilder.Entity<Rating>()
                  .HasOne(rating => rating.To)
                  .WithMany(user => user.RatingsFromMe)
                  .HasForeignKey(rating => rating.ToId)
                  .OnDelete(DeleteBehavior.NoAction)
                  .HasConstraintName("FK_Ratings_ToId");
            modelBuilder.Entity<Rating>()
                  .HasOne(rating => rating.From)
                  .WithMany(user => user.RatingsToMe)
                  .HasForeignKey(rating => rating.FromId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_Ratings_FromId");


            //modelBuilder.Entity<Project>()
            //       .HasOne(project => project.Team)
            //       .WithMany(team => team.Projects)
            //       .HasForeignKey(project => project.TeamId)
            //       .OnDelete(DeleteBehavior.Cascade)
            //       .HasConstraintName("FK_Projects_TeamId");

        }
    }
}
