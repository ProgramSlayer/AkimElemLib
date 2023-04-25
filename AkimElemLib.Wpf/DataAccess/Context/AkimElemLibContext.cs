using AkimElemLib.Wpf.Models.CctvCams;
using AkimElemLib.Wpf.Models.Common;
using AkimElemLib.Wpf.Models.Intruders;
using AkimElemLib.Wpf.Models.SpecificObjects;
using AkimElemLib.Wpf.Models.SpecificObjects.AerialConstructions;
using AkimElemLib.Wpf.Models.SpecificObjects.Buildings;
using AkimElemLib.Wpf.Models.SpecificObjects.SpecificAreas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AkimElemLib.Wpf.DataAccess.Context;

public class AkimElemLibContext : DbContext
{
    public AkimElemLibContext(DbContextOptions<AkimElemLibContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AkimElemLibContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Probability>()
            .HaveConversion<ProbabilityConverter>();
    }

    public DbSet<Intruder> Intruders { get; set; }
    public DbSet<SpecificArea> SpecificAreas { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<AerialConstruction> AerialConstructions { get; set; }
    public DbSet<StationaryCctvCam> StationaryCctvCams { get; set; }
}

public class ProbabilityConverter : ValueConverter<Probability, double>
{
    public ProbabilityConverter() : base(
        p => p.Value,
        p => new Probability(p))
    {
    }
}

public class IntruderEntityTypeConfiguration : IEntityTypeConfiguration<Intruder>
{
    public void Configure(EntityTypeBuilder<Intruder> builder)
    {
        builder.ToTable(nameof(Intruder));
        builder.HasKey(i => i.Id);
        builder.OwnsOne(i => i.VelocityParams);
        builder.OwnsOne(i => i.AccomplicesParams);
        builder.OwnsOne(i => i.CarParams);
        builder.OwnsOne(i => i.PsychophysicalParams);
        builder.OwnsOne(i => i.LightEquipment);
        builder.OwnsOne(i => i.MediumEquipment);
        builder.OwnsOne(i => i.HeavyEquipment);
        builder.OwnsOne(i => i.LengthParams);
        builder.OwnsOne(i => i.HeightParams);
        builder.OwnsOne(i => i.WidthParams);
    }
}

public class SpecificObjectBaseEntityTypeConfiguration : IEntityTypeConfiguration<SpecificObjectBase>
{
    public void Configure(EntityTypeBuilder<SpecificObjectBase> builder)
    {
        builder.ToTable(nameof(SpecificObjectBase));
        builder.UseTphMappingStrategy();
        builder.HasKey(so => so.Id);
    }
}

public class StationaryCctvCamEntityTypeConfiguration : IEntityTypeConfiguration<StationaryCctvCam>
{
    public void Configure(EntityTypeBuilder<StationaryCctvCam> builder)
    {
        builder.ToTable(nameof(StationaryCctvCam));
        builder.HasKey(c => c.Id);
        builder.OwnsOne(c => c.VariofocalLensParams);
    }
}