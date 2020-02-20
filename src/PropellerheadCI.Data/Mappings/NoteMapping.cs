using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Data.Mappings
{
    public class NoteMapping : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Message)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Notes");
        }
    }
}
