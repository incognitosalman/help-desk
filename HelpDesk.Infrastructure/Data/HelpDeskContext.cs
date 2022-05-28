using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HelpDesk.Domain.Entities;

namespace HelpDesk.Infrastructure.Data
{
    public partial class HelpDeskContext : DbContext
    {
        public HelpDeskContext()
        {
        }

        public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TicketAttachment> TicketAttachments { get; set; } = null!;
        public virtual DbSet<TicketGroup> TicketGroups { get; set; } = null!;
        public virtual DbSet<TicketPriority> TicketPriorities { get; set; } = null!;
        public virtual DbSet<TicketSource> TicketSources { get; set; } = null!;
        public virtual DbSet<TicketState> TicketStates { get; set; } = null!;
        public virtual DbSet<TicketTag> TicketTags { get; set; } = null!;
        public virtual DbSet<TicketType> TicketTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MALIK\\TSQL16;Database=HelpDeskDb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Subject).HasMaxLength(100);

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK_Ticket_Users");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Ticket_TicketGroup");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_TicketPriority");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK_Ticket_TicketSource");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_TicketState");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Ticket_TicketType");
            });

            modelBuilder.Entity<TicketAttachment>(entity =>
            {
                entity.ToTable("TicketAttachment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileExtension).HasMaxLength(10);

                entity.Property(e => e.FileName).HasMaxLength(250);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketAttachments)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketAttachment_Ticket");
            });

            modelBuilder.Entity<TicketGroup>(entity =>
            {
                entity.ToTable("TicketGroup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TicketPriority>(entity =>
            {
                entity.ToTable("TicketPriority");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TicketSource>(entity =>
            {
                entity.ToTable("TicketSource");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TicketState>(entity =>
            {
                entity.ToTable("TicketState");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TicketTag>(entity =>
            {
                entity.ToTable("TicketTag");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketTags)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketTag_Ticket");
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.ToTable("TicketType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
