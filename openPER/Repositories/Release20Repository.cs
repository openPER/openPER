﻿using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Caching.Memory;
using openPER.Interfaces;
using openPER.Models;
using System;

namespace openPER.Repositories
{
    public class Release20Repository : IRepository

    {
        private readonly IMemoryCache _cache;
        public Release20Repository(IMemoryCache cache)
        {
            _cache = cache;
        }
        public TableViewModel GetTable(string makeCode, string modelCode, string catalogueCode, string groupCode, string subGroupCode, string languageCode)
        {
            var t = new TableViewModel();
            using (var connection = new SqliteConnection(@"Data Source=C:\Temp\ePerOutput\eperRelease20.db"))
            {
                connection.Open();
                t.MakeDesc = GetMakeDescription(makeCode, connection);
                t.ModelDesc = GetModelDescription(makeCode, modelCode, connection);
                t.CatalogueDesc = GetCatalogueDescription(makeCode, modelCode, catalogueCode, connection);
            }
            return t;
        }

        private string GetCatalogueDescription(string makeCode, string modelCode, string catalogueCode, SqliteConnection connection)
        {
            var cacheKeys = new { type = "CAT", k1 = modelCode, k2 = catalogueCode };
            if (!_cache.TryGetValue(cacheKeys, out string rc))
            {
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT CMD_DSC FROM COMM_MODELS WHERE MOD_COD = $modelCode AND CAT_COD = $catalogueCode ";
                command.Parameters.AddWithValue("$modelCode", modelCode);
                command.Parameters.AddWithValue("$catalogueCode", catalogueCode);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rc = reader.GetString(0);
                    }
                }
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));
                _cache.Set(cacheKeys, rc, cacheEntryOptions);
            }
            return rc;
        }

        private static string GetMakeDescription(string makeCode, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT MK_DSC FROM MAKES WHERE MK_COD = $makeCode";
            command.Parameters.AddWithValue("$makeCode", makeCode);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            return "";
        }
        private static string GetModelDescription(string makeCode, string modelCode, SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT MOD_DSC FROM MODELS WHERE MK_COD = $makeCode AND MOD_COD = $modelCode";
            command.Parameters.AddWithValue("$makeCode", makeCode);
            command.Parameters.AddWithValue("$modelCode", modelCode);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            return "";
        }
    }
}
