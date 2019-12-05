namespace Pidev.data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("Model1")
        {
        }

        public virtual DbSet<employe> employe { get; set; }
        public virtual DbSet<tp_jsf_employe> tp_jsf_employe { get; set; }
        public virtual DbSet<tp_jsf_project> tp_jsf_project { get; set; }
        public virtual DbSet<tp_jsf_reclamation> tp_jsf_reclamation { get; set; }
        public virtual DbSet<tp_jsf_tache> tp_jsf_tache { get; set; }
        public virtual DbSet<tp_jsf_timesheet> tp_jsf_timesheet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_employe>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_project>()
                .Property(e => e.descp)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_project>()
                .Property(e => e.nomp)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_reclamation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_reclamation>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_reclamation>()
                .Property(e => e.rep)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_tache>()
                .Property(e => e.desct)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_tache>()
                .Property(e => e.nomt)
                .IsUnicode(false);

            modelBuilder.Entity<tp_jsf_timesheet>()
                .Property(e => e.EtatTache)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<Pidev.data.testt> testts { get; set; }
    }
}
