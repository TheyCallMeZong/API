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
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("value").AsInt64()
                .WithColumn("time").AsInt64();
            Create.Table("dotnetmetrics")
               .WithColumn("id").AsInt64().PrimaryKey().Identity()
               .WithColumn("value").AsInt64()
               .WithColumn("time").AsInt64(); 
            Create.Table("hddmetrics")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("freesize").AsInt64()
                .WithColumn("time").AsInt64(); 
            Create.Table("networkmetrics")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("value").AsInt64()
                .WithColumn("time").AsInt64(); 
            Create.Table("rammetrics")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("available").AsInt64()
                .WithColumn("time").AsInt64();
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
