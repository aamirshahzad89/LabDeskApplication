namespace LabDeskApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.LogInitialArticle",
            //    c => new
            //    {
            //        ArticleID = c.Int(nullable: false, identity: true),
            //        StyleCode = c.String(),
            //        ProductID = c.Int(nullable: false),
            //        LabID = c.String(maxLength: 128),
            //    })
            //    .PrimaryKey(t => t.ArticleID)
            //    .ForeignKey("dbo.LogInitialVendor", t => t.LabID)
            //    .ForeignKey("dbo.SetupProduct", t => t.ProductID, cascadeDelete: true)
            //    .Index(t => t.ProductID)
            //    .Index(t => t.LabID);

            //CreateTable(
            //    "dbo.LogInitialVendor",
            //    c => new
            //        {
            //            LabID = c.String(nullable: false, maxLength: 128),
            //            FormDate = c.DateTime(nullable: false),
            //            Composition = c.String(),
            //            VendorID = c.Int(nullable: false),
            //            SetupColour_ColourID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.LabID)
            //    .ForeignKey("dbo.SetupVendor", t => t.VendorID, cascadeDelete: true)
            //    .ForeignKey("dbo.SetupColor", t => t.SetupColour_ColourID)
            //    .Index(t => t.VendorID)
            //    .Index(t => t.SetupColour_ColourID);
            
            //CreateTable(
            //    "dbo.SetupVendor",
            //    c => new
            //        {
            //            VendorName = c.String(),
            //            VendorID = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.VendorID);
            
            //CreateTable(
            //    "dbo.SetupProduct",
            //    c => new
            //        {
            //            ProductID = c.Int(nullable: false, identity: true),
            //            ProductName = c.String(),
            //        })
            //    .PrimaryKey(t => t.ProductID);
            
            //CreateTable(
            //    "dbo.LogInitialStyle",
            //    c => new
            //        {
            //            StyleID = c.Int(nullable: false, identity: true),
            //            SampleDate = c.DateTime(nullable: false),
            //            Sample = c.String(),
            //            Volume = c.Int(nullable: false),
            //            Year = c.Int(nullable: false),
            //            Width = c.String(),
            //            ColourID = c.Int(nullable: false),
            //            ArticleTypeId = c.Int(nullable: false),
            //            ResultID = c.Int(nullable: false),
            //            UserID = c.Int(nullable: false),
            //            ArticleID = c.Int(nullable: false),
            //            LogInitialVendor_LabID = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.StyleID)
            //    .ForeignKey("dbo.LogInitialArticle", t => t.ArticleID, cascadeDelete: true)
            //    .ForeignKey("dbo.LogInitialVendor", t => t.LogInitialVendor_LabID)
            //    .ForeignKey("dbo.SetupArticleType", t => t.ArticleTypeId, cascadeDelete: true)
            //    .ForeignKey("dbo.SetupColor", t => t.ColourID, cascadeDelete: true)
            //    .ForeignKey("dbo.SetupResult", t => t.ResultID, cascadeDelete: true)
            //    .ForeignKey("dbo.SetupUserInfo", t => t.UserID, cascadeDelete: true)
            //    .Index(t => t.ColourID)
            //    .Index(t => t.ArticleTypeId)
            //    .Index(t => t.ResultID)
            //    .Index(t => t.UserID)
            //    .Index(t => t.ArticleID)
            //    .Index(t => t.LogInitialVendor_LabID);
            
            //CreateTable(
            //    "dbo.SetupArticleType",
            //    c => new
            //        {
            //            ArticleTypeId = c.Int(nullable: false, identity: true),
            //            ArticleType = c.String(),
            //        })
            //    .PrimaryKey(t => t.ArticleTypeId);
            
            //CreateTable(
            //    "dbo.SetupColor",
            //    c => new
            //        {
            //            ColourID = c.Int(nullable: false, identity: true),
            //            ColourName = c.String(),
            //        })
            //    .PrimaryKey(t => t.ColourID);
            
            //CreateTable(
            //    "dbo.SetupResult",
            //    c => new
            //        {
            //            ResultID = c.Int(nullable: false, identity: true),
            //            ResultName = c.String(),
            //        })
            //    .PrimaryKey(t => t.ResultID);
            
            //CreateTable(
            //    "dbo.TestValues",
            //    c => new
            //        {
            //            TestNameID = c.Int(nullable: false, identity: true),
            //            TestDate = c.DateTime(nullable: false),
            //            TestApproachID = c.Int(nullable: false),
            //            TestValues01 = c.String(),
            //            TestValues02 = c.String(),
            //            TestValues03 = c.String(),
            //            TestValues04 = c.String(),
            //            TestValues05 = c.String(),
            //            ResultID = c.Int(nullable: false),
            //            StyleID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.TestNameID)
            //    .ForeignKey("dbo.LogInitialStyle", t => t.StyleID, cascadeDelete: true)
            //    .ForeignKey("dbo.SetupResult", t => t.ResultID, cascadeDelete: true)
            //    .ForeignKey("dbo.TestApproach", t => t.TestApproachID, cascadeDelete: true)
            //    .Index(t => t.TestApproachID)
            //    .Index(t => t.ResultID)
            //    .Index(t => t.StyleID);
            
            //CreateTable(
            //    "dbo.TestApproach",
            //    c => new
            //        {
            //            TestApproachID = c.Int(nullable: false, identity: true),
            //            TestName = c.String(),
            //            TestStandard = c.String(),
            //            TestApproachName01 = c.String(),
            //            TestApproachName02 = c.String(),
            //            TestApproachName03 = c.String(),
            //            TestApproachName04 = c.String(),
            //            TestApproachName05 = c.String(),
            //            Remarks = c.String(),
            //        })
            //    .PrimaryKey(t => t.TestApproachID);
            
            //CreateTable(
            //    "dbo.SetupUserInfo",
            //    c => new
            //        {
            //            UserID = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //            Password = c.String(),
            //            Role = c.String(),
            //        })
            //    .PrimaryKey(t => t.UserID);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            //DropForeignKey("dbo.LogInitialStyle", "UserID", "dbo.SetupUserInfo");
            //DropForeignKey("dbo.LogInitialStyle", "ResultID", "dbo.SetupResult");
            //DropForeignKey("dbo.TestValues", "TestApproachID", "dbo.TestApproach");
            //DropForeignKey("dbo.TestValues", "ResultID", "dbo.SetupResult");
            //DropForeignKey("dbo.TestValues", "StyleID", "dbo.LogInitialStyle");
            //DropForeignKey("dbo.LogInitialStyle", "ColourID", "dbo.SetupColor");
            //DropForeignKey("dbo.LogInitialVendor", "SetupColour_ColourID", "dbo.SetupColor");
            //DropForeignKey("dbo.LogInitialStyle", "ArticleTypeId", "dbo.SetupArticleType");
            //DropForeignKey("dbo.LogInitialStyle", "LogInitialVendor_LabID", "dbo.LogInitialVendor");
            //DropForeignKey("dbo.LogInitialStyle", "ArticleID", "dbo.LogInitialArticle");
            //DropForeignKey("dbo.LogInitialArticle", "ProductID", "dbo.SetupProduct");
            //DropForeignKey("dbo.LogInitialArticle", "LabID", "dbo.LogInitialVendor");
            //DropForeignKey("dbo.LogInitialVendor", "VendorID", "dbo.SetupVendor");
            //DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            //DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            //DropIndex("dbo.AspNetUsers", "UserNameIndex");
            //DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            //DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            //DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            //DropIndex("dbo.TestValues", new[] { "StyleID" });
            //DropIndex("dbo.TestValues", new[] { "ResultID" });
            //DropIndex("dbo.TestValues", new[] { "TestApproachID" });
            //DropIndex("dbo.LogInitialStyle", new[] { "LogInitialVendor_LabID" });
            //DropIndex("dbo.LogInitialStyle", new[] { "ArticleID" });
            //DropIndex("dbo.LogInitialStyle", new[] { "UserID" });
            //DropIndex("dbo.LogInitialStyle", new[] { "ResultID" });
            //DropIndex("dbo.LogInitialStyle", new[] { "ArticleTypeId" });
            //DropIndex("dbo.LogInitialStyle", new[] { "ColourID" });
            //DropIndex("dbo.LogInitialVendor", new[] { "SetupColour_ColourID" });
            //DropIndex("dbo.LogInitialVendor", new[] { "VendorID" });
            //DropIndex("dbo.LogInitialArticle", new[] { "LabID" });
            //DropIndex("dbo.LogInitialArticle", new[] { "ProductID" });
            //DropTable("dbo.AspNetUserLogins");
            //DropTable("dbo.AspNetUserClaims");
            //DropTable("dbo.AspNetUsers");
            //DropTable("dbo.AspNetUserRoles");
            //DropTable("dbo.AspNetRoles");
            //DropTable("dbo.SetupUserInfo");
            //DropTable("dbo.TestApproach");
            //DropTable("dbo.TestValues");
            //DropTable("dbo.SetupResult");
            //DropTable("dbo.SetupColor");
            //DropTable("dbo.SetupArticleType");
            //DropTable("dbo.LogInitialStyle");
            //DropTable("dbo.SetupProduct");
            //DropTable("dbo.SetupVendor");
            //DropTable("dbo.LogInitialVendor");
            //DropTable("dbo.LogInitialArticle");
        }
    }
}
