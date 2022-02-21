using System;
using System.Collections;
using System.Collections.Generic;

namespace DotnetCd.Models
{
    public class Util
    {
        public static string getEnv(string key, string _default = null) => _Util.Instance().getEnv(key, _default);
    }

    public class _Util
    {
        private static readonly _Util _instance = new _Util();

        IDictionary envVars;

        private _Util()
        {
            envVars = Environment.GetEnvironmentVariables();
        }

        public static _Util Instance()
        {
            return _instance;
        }

        public string getEnv( string key, string _default )
        {
            string value = envVars.Contains(key) ? envVars[key].ToString() : null;
            return String.IsNullOrEmpty(value) ? _default : value;
        }
    }
}
