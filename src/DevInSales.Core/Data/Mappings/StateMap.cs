using DevInSales.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Core.Data.Mappings
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsUnicode(false).IsRequired();

            builder.Property(x => x.Initials).HasMaxLength(2).IsUnicode(false);

            builder.HasData(
                new List<State>
                {
                    new(1, "Acre", "AC"),
                    new(2, "Alagoas", "AL"),
                    new(3, "Amapá", "AP"),
                    new(4, "Amazonas", "AM"),
                    new(5, "Bahia", "BA"),
                    new(6, "Ceará", "CE"),
                    new(7, "Distrito Federal", "DF"),
                    new(8, "Espírito Santo", "ES"),
                    new(9, "Goiás", "GO"),
                    new(10, "Maranhão", "MA"),
                    new(11, "Mato Grosso", "MT"),
                    new(12, "Mato Grosso do Sul", "MS"),
                    new(13, "Minas Gerais", "MG"),
                    new(14, "Pará", "PA"),
                    new(15, "Paraíba", "PB"),
                    new(16, "Paraná", "PR"),
                    new(17, "Pernambuco", "PE"),
                    new(18, "Piauí", "PI"),
                    new(19, "Rio de Janeiro", "RJ"),
                    new(20, "Rio Grande do Norte", "RN"),
                    new(21, "Rio Grande do Sul", "RS"),
                    new(22, "Rondônia", "RO"),
                    new(23, "Roraima", "RR"),
                    new(24, "Santa Catarina", "SC"),
                    new(25, "São Paulo", "SP"),
                    new(26, "Sergipe", "SE"),
                    new(27, "Tocantins", "TO")
                }
            );
        }
    }
}
