//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AtelierPratique_16.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompagnieVoyageEntities : DbContext
    {
        public CompagnieVoyageEntities()
            : base("name=CompagnieVoyageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<billet> billet { get; set; }
        public virtual DbSet<chauffeur> chauffeur { get; set; }
        public virtual DbSet<Membre> Membre { get; set; }
        public virtual DbSet<Vehicule> Vehicule { get; set; }
        public virtual DbSet<voyage> voyage { get; set; }
    }
}
