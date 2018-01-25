using System;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Spot.StatsManagement.Core.Model;

namespace Spot.StatsManagement.Infrastructure
{
    public class SpotContext:DbContext
    {
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityStat> FacilityStats { get; set; }
        public DbSet<FacilityInfo> FacilityInfos { get; set; }

        public SpotContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacilityStat>()
                .ToTable("FacilityStat")
                .HasKey(x=>x.FacilityId);

            modelBuilder.Entity<FacilityInfo>()
                .ToTable("FacilityInfo")
                .HasKey(x => x.FacilityId);


            modelBuilder.Entity<FacilityStat>().Ignore(x=>x.TimeAgo);

            modelBuilder.Entity<Facility>()
                .HasOne(a => a.Stats)
                .WithOne(b => b.Facility)
                .HasForeignKey<FacilityStat>(b => b.FacilityId);

            modelBuilder.Entity<Facility>()
                .HasOne(a => a.Info)
                .WithOne(b => b.Facility)
                .HasForeignKey<FacilityInfo>(b => b.FacilityId);
        }

        public void CreateViews()
        {
            try
            {
                Database.ExecuteSqlCommand(
                    @"
               
                IF OBJECT_ID('dbo.FacilityStat') IS NULL
                    BEGIN
                        EXECUTE('
	                        
                            create view FacilityStat
	                        as
                            SELECT        
	                            FacilityId, COUNT(Id) AS NoOfPatients,MAX(Created) AS LastUpdate
                            FROM            
	                            PatientExtract
                            GROUP BY 
	                            FacilityId
                            ')
                    END

            ");

            }
            catch (Exception e)
            {
                Log.Debug($"{e}");
            }

            try
            {
                Database.ExecuteSqlCommand(
                    @"
               
                IF OBJECT_ID('dbo.FacilityInfo') IS NULL
                    BEGIN
                        EXECUTE('
	                        
                            create view FacilityInfo
	                        as
                           SELECT        
	                            FacilityId, County
                            FROM            
	                            MasterFacility
							Where
								FacilityId is not null
                            ')
                    END

            ");

            }
            catch (Exception e)
            {
                Log.Debug($"{e}");
            }
        }
    }
}