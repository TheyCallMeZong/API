using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Migrarions
{
    [Migration(1)]
    public class FirstMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("agentinfo");
            Delete.Table("cpumetrics");
            Delete.Table("dotnetmetrics");
            Delete.Table("hddmetrics");
            Delete.Table("networkmetrics");
            Delete.Table("rammetrics");
        }

        public override void Up()
        {
            Create.Table("agentinfo")
                .WithColumn("agentId").AsInt64().PrimaryKey().Identity()
                .WithColumn("uri").AsString();
            Create.Table("cpumetrics")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("agentId").AsInt64()
                .WithColumn("value").AsInt64()
                .WithColumn("time").AsInt64();
            Create.Table("dotnetmetrics")
               .WithColumn("id").AsInt64().PrimaryKey().Identity()
               .WithColumn("agentId").AsInt64()
               .WithColumn("value").AsInt64()
               .WithColumn("time").AsInt64();
            Create.Table("hddmetrics")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("agentId").AsInt64()
                .WithColumn("freesize").AsInt64()
                .WithColumn("time").AsInt64();
            Create.Table("networkmetrics")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("agentId").AsInt64()
                .WithColumn("value").AsInt64()
                .WithColumn("time").AsInt64();
            Create.Table("rammetrics")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("agentId").AsInt64()
                .WithColumn("available").AsInt64()
                .WithColumn("time").AsInt64();
        }
    }
}
