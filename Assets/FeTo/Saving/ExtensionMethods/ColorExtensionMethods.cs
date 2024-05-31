using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace FeTo.Saving
{
    public static class ColorExtensionMethods
    {
        public static JToken ToToken(this Color color)
        {
            JObject state = new JObject();
            IDictionary<string, JToken> stateDict = state;
            stateDict["r"] = color.r;
            stateDict["g"] = color.g;
            stateDict["b"] = color.b;
            stateDict["a"] = color.a;
            return state;
        }

        public static Color ToColor(this JToken state)
        {
            Color color = new Color();
            if (state is JObject jObject)
            {
                IDictionary<string, JToken> stateDict = jObject;

                if (stateDict.TryGetValue("r", out JToken r))
                {
                    color.r = r.ToObject<float>();
                }

                if (stateDict.TryGetValue("g", out JToken g))
                {
                    color.g = g.ToObject<float>();
                }

                if (stateDict.TryGetValue("b", out JToken b))
                {
                    color.b = b.ToObject<float>();
                }

                if (stateDict.TryGetValue("a", out JToken a))
                {
                    color.a = a.ToObject<float>();
                }
            }
            return color;
        }

    }
}
