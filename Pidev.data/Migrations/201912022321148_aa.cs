namespace Pidev.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "louai.employe",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(maxLength: 255, unicode: false),
                        isActif = c.Boolean(storeType: "bit"),
                        login = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        role = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "louai.tp_jsf_employe",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(maxLength: 255, unicode: false),
                        isActif = c.Boolean(storeType: "bit"),
                        nom = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        prenom = c.String(maxLength: 255, unicode: false),
                        role = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "louai.tp_jsf_project",
                c => new
                    {
                        idp = c.Int(nullable: false, identity: true),
                        descp = c.String(maxLength: 255, unicode: false),
                        endDate = c.DateTime(precision: 0),
                        nomp = c.String(maxLength: 255, unicode: false),
                        startDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.idp);
            
            CreateTable(
                "louai.tp_jsf_reclamation",
                c => new
                    {
                        idRec = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        idemp = c.Int(nullable: false),
                        name = c.String(maxLength: 255, unicode: false),
                        rep = c.String(maxLength: 255, unicode: false),
                        emps_id = c.Int(),
                    })
                .PrimaryKey(t => t.idRec);
            
            CreateTable(
                "louai.tp_jsf_tache",
                c => new
                    {
                        idt = c.Int(nullable: false, identity: true),
                        EndDate = c.DateTime(precision: 0),
                        StartDate = c.DateTime(precision: 0),
                        desct = c.String(maxLength: 255, unicode: false),
                        nomt = c.String(maxLength: 255, unicode: false),
                        employes_id = c.Int(),
                        id = c.Int(),
                        timesheets_idT = c.Int(),
                    })
                .PrimaryKey(t => t.idt);
            
            CreateTable(
                "louai.tp_jsf_timesheet",
                c => new
                    {
                        idT = c.Int(nullable: false, identity: true),
                        EtatTache = c.String(maxLength: 255, unicode: false),
                        NbreConge = c.Int(nullable: false),
                        NbreHeureTRavJour = c.Int(nullable: false),
                        NbreHeureTRavS = c.Int(nullable: false),
                        etat = c.Int(),
                        idEmploye = c.Int(),
                        idpfk = c.Int(),
                    })
                .PrimaryKey(t => t.idT);
            
        }
        
        public override void Down()
        {
            DropTable("louai.tp_jsf_timesheet");
            DropTable("louai.tp_jsf_tache");
            DropTable("louai.tp_jsf_reclamation");
            DropTable("louai.tp_jsf_project");
            DropTable("louai.tp_jsf_employe");
            DropTable("louai.employe");
        }
    }
}
