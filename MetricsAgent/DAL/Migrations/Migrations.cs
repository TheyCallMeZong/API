using FluentMigrator;
using System;

namespace MetricsAgent.DAL.Migrations
{
    [Migration(1)]
    public class Migrations : Migration
    {
        public override void Up()
        {
            Create.Table("cpumetrics")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("value").AsInt32().NotNullable()
                .WithColumn("time").AsInt32().NotNullable();
            Create.Table("dotnetmetrics")
               .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
               .WithColumn("value").AsInt32().NotNullable()
               .WithColumn("time").AsInt32().NotNullable(); 
            Create.Table("hddmetrics")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("freesize").AsInt32().NotNullable()
                .WithColumn("time").AsInt32().NotNullable(); 
            Create.Table("networkmetrics")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("value").AsInt32().NotNullable()
                .WithColumn("time").AsInt32().NotNullable(); 
            Create.Table("rametics")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("available").AsInt32().NotNullable()
                .WithColumn("time").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("cpumetrics");
            Delete.Table("dotnetmetrics");
            Delete.Table("hddmetrics");
            Delete.Table("networkmetrics");
            Delete.Table("rammetrics");
        }

    }
}
