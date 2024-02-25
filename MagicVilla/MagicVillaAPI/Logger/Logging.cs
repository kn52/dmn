

using MagicVillaAPI.Constants;

namespace MagicVillaAPI.Logger
{
    public class Logging : ILogging
    {
        public void Log(string type = "", string message = "")
        {
            switch (type)
            {
                case ConstantValues.INFO:
                    PrintLog(string.Format("Information: {0}", message));
                        break; 
                case ConstantValues.ERROR:
                    PrintLog(string.Format("Error: {0}", message));
                    break;
                case ConstantValues.SUCCESS:
                    PrintLog(string.Format("Success: {0}", message));
                    break;
            };
        }
        private void PrintLog(string message)
        {
            Console.WriteLine(message);
        }

    }
}