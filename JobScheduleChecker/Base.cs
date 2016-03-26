using log4net;

namespace JobScheduleChecker
{
    class Base
    {
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
