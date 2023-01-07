using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sololearn.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.utils
{
    public static class QueryGenerator
    {
        public delegate string GenerateQuery(string tableName, Dictionary<string, string> args);

        public static string GenericQueryGenerator(string tableName, Dictionary<string, string> args, GenerateQuery generateQuery)
        {
            return generateQuery(tableName, args);
        }

        public static string GenerateInsertQuery(string tableName, Dictionary<string, string> args)
        {
            StringBuilder sb = new StringBuilder($"INSERT INTO {tableName}( ");

            Dictionary<string, string>.Enumerator enumerator = args.GetEnumerator();

            while (enumerator.MoveNext())
            {
                KeyValuePair<string, string> current = enumerator.Current;
                sb.Append(current.Key);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(") values ( ");

            enumerator = args.GetEnumerator();

            while (enumerator.MoveNext())
            {
                KeyValuePair<string, string> current = enumerator.Current;
                sb.Append("'" + current.Value + "', ");
            }

            sb.Remove(sb.Length - 2, 2);

            sb.Append(" );");

            return sb.ToString();

        }

        public static string GenerateUpdateQuery(string tableName, Dictionary<string, string> args)
        {
            StringBuilder sb = new($"UPDATE FROM {tableName} SET ");

            Dictionary<string, string>.Enumerator enumerator = args.GetEnumerator();

            enumerator.MoveNext();
            string whereKey = enumerator.Current.Key;
            string whereVal = enumerator.Current.Value;

            while (enumerator.MoveNext())
            {
                KeyValuePair<string, string> current = enumerator.Current;
                sb.Append(current.Key);
                sb.Append(" = ");
                sb.Append(current.Value);
            }

            sb.Append($"WHERE {whereKey} = ''{whereVal}'");
            return sb.ToString();

        }

        internal static string GenerateDeleteQuery(string tableName, Dictionary<string, string> args)
        {
            StringBuilder sb = new($"DELETE FROM {tableName} ");

            Dictionary<string, string>.Enumerator enumerator = args.GetEnumerator();

            enumerator.MoveNext();
            string whereKey = enumerator.Current.Key;
            string whereVal = enumerator.Current.Value;

            sb.Append($"WHERE {whereKey} = '{whereVal}'");
            return sb.ToString();
        }

        internal static string GenerateSelectByQuery(string tableName, Dictionary<string, string> args)
        {
            StringBuilder sb = new($"SELECT * FROM {tableName} ");

            Dictionary<string, string>.Enumerator enumerator = args.GetEnumerator();

            enumerator.MoveNext();
            string whereKey = enumerator.Current.Key;
            string whereVal = enumerator.Current.Value;
            sb.Append($"WHERE {whereKey} = '{whereVal}'");
            return sb.ToString();
        }

        internal static string GenerateSelectAllQuery(string tableName)
        {
            StringBuilder sb = new StringBuilder($"SELECT * FROM {tableName};");
            return sb.ToString();
        }
    }
}
