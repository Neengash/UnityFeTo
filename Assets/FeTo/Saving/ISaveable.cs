using Newtonsoft.Json.Linq;

namespace FeTo.Saving
{
    public interface ISaveable
    {
        JToken CaptureAsJToken();
        void RestoreFromJToken(JToken state);
    }
}