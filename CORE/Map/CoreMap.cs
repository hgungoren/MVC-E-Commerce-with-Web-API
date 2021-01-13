using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CORE.CoreEntity;

namespace CORE.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : EntityRepository
        //Attr işlemi yerine maping işlemleri tanımlandı. 
    {
        public CoreMap()
        {
            Property(x => x.CreatedAdUserName).HasColumnName("CreatedAdUserName").IsOptional();

            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName").IsOptional();

            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsOptional();

            Property(x => x.UpdatedIP).HasColumnName("UpdatedIP").IsOptional();
            Property(x => x.MasterId).IsOptional();

        }
    }
}
