using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Api.Common.Constants
{
    public class ConnectionStringName
    {
        public const string SAMPLE_WRITE = "sample_write";
        /// <summary>
        /// MSSQL 연결문자열
        /// </summary>
        public const string MSDB_READ = "msdb_read";
        public const string MSDB_WRITE = "msdb_write";

        public const string MSDB2_READ = "msdb2_read";
        public const string MSDB2_WRITE = "msdb2_write";

        /// <summary>
        /// ORACLE 연결문자열
        /// </summary>
        public const string ORACLE_READ = "oracle_read";
        public const string ORACLE_WRITE = "oracle_write";
    }}