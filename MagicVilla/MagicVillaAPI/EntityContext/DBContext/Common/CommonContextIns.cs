namespace MagicVillaAPI.EntityContext.DBContext.Common
{
    public class CommonContextIns
    {
        public readonly CommonDBContext _db;

        public CommonContextIns(CommonDBContext db)
        {
            _db = db;
        }
    }
}
