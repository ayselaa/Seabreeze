using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeaBreeze.Domain.Entity.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Domain.Configurations
{
    internal class StaticLocalizationTranslateConfiguration : IEntityTypeConfiguration<StaticLocalizationTranslate>
    {
        public void Configure(EntityTypeBuilder<StaticLocalizationTranslate> builder)
        {
            builder.HasKey(tr => new { tr.Key, tr.LangCode });

        }
    }
}
