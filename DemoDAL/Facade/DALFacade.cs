using DAL.UOW;

namespace DAL.Facade
{
    public class DALFacade : IDALFacade
    {
        public DALFacade() { }

        DbOptions opt;
        public DALFacade(DbOptions opt){
            this.opt = opt;
        }

        public IUnitOfWork UnitOfWork
		{
			get
			{
                return new UnitOfWork(opt);
			}
		}

    }
}
