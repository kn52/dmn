namespace MagicVillaAPI.EntityContext.DBContext.Common
{
    public class ICommonContextIns
    {
        private ICommonContextIns db;

        public ICommonContextIns(ICommonContextIns db)
        {
            this.db = db;
        }
    }
}
